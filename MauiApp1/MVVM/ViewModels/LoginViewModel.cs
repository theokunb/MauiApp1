using MauiApp1.Helpers;
using MauiApp1.MVVM.Models;
using MauiApp1.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiApp1.MVVM.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public LoginViewModel()
        {
            var lastToken = Preferences.Get(Strings.AuthToken, string.Empty);
            if (!string.IsNullOrEmpty(lastToken))
                Shell.Current.GoToAsync("//WorkSpace");

            CommandLogin = new Command((param) => ButtonloginClicked(param));
            CommandSignUp = new Command((param) => SignUp_Tapped(param));
            CommandPickerChanged = new Command((param)=> Picker_SelectedIndexChanged(param));


            Languages = new ObservableCollection<Language>();
            foreach (var element in Localizator.Instance.Languages)
            {
                Languages.Add(element);
            }


            OnPropertyChanged(nameof(SelectedLanguage));
            OnPropertyChanged(nameof(Languages));

            IsBusy = false;
        }

        private string email;
        private string password;



        public ICommand CommandPickerChanged { get; }
        public ICommand CommandLogin { get; }
        public ICommand CommandSignUp { get; }
        public string DisplayTitle => Localizator.Instance.SelectedLanguage.Login;
        public string DisplaySignIn => Localizator.Instance.SelectedLanguage.SignIn;
        public string DisplaySignUp => Localizator.Instance.SelectedLanguage.SignUp;
        public string DisplayNoAccount => Localizator.Instance.SelectedLanguage.NoAccount;
        public string DisplayForgotPassword => Localizator.Instance.SelectedLanguage.ForgotPassword;
        public string DisplayPassword => Localizator.Instance.SelectedLanguage.Password;
        public string DisplayEmail => Localizator.Instance.SelectedLanguage.Email;
        public ObservableCollection<Language> Languages { get; set; }
        public string Email
        {
            get => email;
            set
            {
                email = value;
                OnPropertyChanged(nameof(Email));
            }
        }
        public string Password
        {
            get => password;
            set
            {
                password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public Language SelectedLanguage
        {
            get => Localizator.Instance.SelectedLanguage;
        }


        private async void ButtonloginClicked(object param)
        {
            if (IsBusy)
                return;
            IsBusy = true;

            var result = await FBAuth.FireBaseAuth.SingIn(Email, Password);
            if (result)
                await Shell.Current.GoToAsync("//WorkSpace");

            IsBusy = false;
        }

        private void Picker_SelectedIndexChanged(object param)
        {
            Localizator.Instance.SelectedLanguage = param as Language;
            OnPropertyChanged(null);
        }

        private async void SignUp_Tapped(object param)
        {
            if (IsBusy)
                return;
            IsBusy = true;
            await Shell.Current.GoToAsync($"{nameof(SignUpPage)}");
            IsBusy = false;
        }
    }
}
