using MauiApp1.MVVM.Models;
using MauiApp1.Services;
using System.Windows.Input;

namespace MauiApp1.MVVM.ViewModels
{
    public class SignUpViewModel : BaseViewModel
    {
        public SignUpViewModel()
        {
			CommandSignUp = new Command((param) => SignUpClicked(param));
			OnPropertyChanged(null);
        }

        

        private string email;
		private string password1;
		private string password2;
		private bool isAccepted;


		public string DisplayTitle => Localizator.Instance.SelectedLanguage.SignUp;
		public string DisplayEmail => Localizator.Instance.SelectedLanguage.Email;
		public string DisplayPassword => Localizator.Instance.SelectedLanguage.Password;
		public string DisplayRepeatPassword => Localizator.Instance.SelectedLanguage.RepeatPassword;
		public string DisplayIAgreeWith => Localizator.Instance.SelectedLanguage.IAgreeWith;
		public string DisplayTermOfUserAgreement => Localizator.Instance.SelectedLanguage.TermsOfUserAgreement;
		public string DisplaySignUp => Localizator.Instance.SelectedLanguage.SignUp;

		public ICommand CommandSignUp { get; }
		public bool IsAccepted
		{
			get => isAccepted;
			set
			{
				isAccepted = value;
				OnPropertyChanged(nameof(IsAccepted));
			}
		}
		public string Password2
		{
			get => password2;
			set
			{
				password2 = value;
				OnPropertyChanged(nameof(Password2));
			}
		}
		public string Password1
		{
			get => password1;
			set
			{
				password1 = value;
				OnPropertyChanged(nameof(Password1));
			}
		}
		public string Email
		{
			get => email;
			set
			{
				email = value;
				OnPropertyChanged(nameof(Email));
			}
		}


		private async void SignUpClicked(object param)
		{
			if (IsBusy)
				return;
			IsBusy = true;

			if (Password1 != Password2)
			{
				IsBusy = false;
				await Shell.Current.DisplayAlert(Localizator.Instance.SelectedLanguage.Warning, Localizator.Instance.SelectedLanguage.PasswordsDoNotMatch, Localizator.Instance.SelectedLanguage.Ok);
				return;
			}
			var result = await FBAuth.FireBaseAuth.CreateUser(Email, Password1);
			if (!result)
			{
				IsBusy = false;
				await Shell.Current.DisplayAlert(Localizator.Instance.SelectedLanguage.Warning, Localizator.Instance.SelectedLanguage.EmailAlreadyBusy, Localizator.Instance.SelectedLanguage.Ok);
				return;
			}

			UserProfile userProfile = new()
			{
				Name = string.Empty,
				LastName = string.Empty,
				Gender = string.Empty,
				City = string.Empty,
				DateOfBirth = string.Empty,
				Email = Email
			};

			await RealTimeDB.RealTimeDatabase.CreateUser(userProfile);
			IsBusy = false;
			await Shell.Current.GoToAsync("..");
		}
	}
}
