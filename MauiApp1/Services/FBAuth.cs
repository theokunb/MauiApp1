using Firebase.Auth;
using MauiApp1.Helpers;
using MauiApp1.MVVM.Models;
using Newtonsoft.Json;

namespace MauiApp1.Services
{
    internal class FBAuth : IAuthProvider
    {
        FBAuth()
        {
            firebaseAuth = new FirebaseAuthProvider(new FirebaseConfig(WebAPIKey));
        }

        private const string WebAPIKey = "AIzaSyBEc_IxwDBz3SR2ZNyEN4s8sUxh1yBGuIc";
        private readonly FirebaseAuthProvider firebaseAuth;

        public static FBAuth FireBaseAuth => new FBAuth();

        public async Task<bool> SingIn(string email, string password)
        {
            try
            {
                var auth = await firebaseAuth.SignInWithEmailAndPasswordAsync(email, password);
                var freshAuth = await auth.GetFreshAuthAsync();

                string serializedAuth = JsonConvert.SerializeObject(freshAuth);
                Preferences.Set(Strings.AuthToken, serializedAuth);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<FirebaseAuth> GetProfileInfo()
        {
            FirebaseAuth savedFirebaseAuth = JsonConvert.DeserializeObject<FirebaseAuth>(Preferences.Get(Strings.AuthToken, string.Empty));
            var refreshedAuth = await firebaseAuth.RefreshAuthAsync(savedFirebaseAuth);
            Preferences.Set(Strings.AuthToken, JsonConvert.SerializeObject(refreshedAuth));
            return savedFirebaseAuth;
        }

        public async Task<bool> CreateUser(string email, string password)
        {
            try
            {
                var createUser = await firebaseAuth.CreateUserWithEmailAndPasswordAsync(email, password, sendVerificationEmail: true);
                var firebaseToken = createUser.FirebaseToken;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
