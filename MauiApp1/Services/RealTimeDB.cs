using Firebase.Database;
using MauiApp1.Helpers;
using MauiApp1.MVVM.Models;
using Newtonsoft.Json;
using System.Text;

namespace MauiApp1.Services
{
    internal class RealTimeDB
    {
        private RealTimeDB()
        {
            client = new FirebaseClient(key);
        }

        public static RealTimeDB RealTimeDatabase => new RealTimeDB();

        private const string key = "https://testmaui-ae782-default-rtdb.europe-west1.firebasedatabase.app/";
        private FirebaseClient client;



        private string GetUserNameFromEmail(string email)
        {
            return email.Split('@').First();
        }

        public async Task<UserProfile> GetUser(string userEmail)
        {
            return (await client.Child(Strings.TableUsers).OnceAsync<UserProfile>()).Select(element => element.Object).ToList().Find(element => element.Email == userEmail);
        }

        public async Task CreateUser(UserProfile userProfile)
        {
            StringBuilder path = new StringBuilder().
                Append(Strings.TableUsers).
                Append("/").
                Append(GetUserNameFromEmail(userProfile.Email));
            var content = JsonConvert.SerializeObject(userProfile);
            await client.Child(path.ToString()).PutAsync(content);
        }

        public async Task PatchUser(UserProfile userProfile)
        {
            StringBuilder path = new StringBuilder().
                Append(Strings.TableUsers).
                Append("/").
                Append(GetUserNameFromEmail(userProfile.Email));
            var content = JsonConvert.SerializeObject(userProfile);
            await client.Child(path.ToString()).PatchAsync(content);
        }
    }
}
