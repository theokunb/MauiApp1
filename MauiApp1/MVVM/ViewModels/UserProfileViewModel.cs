using Firebase.Auth;
using MauiApp1.MVVM.Models;
using MauiApp1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiApp1.MVVM.ViewModels
{
    public class UserProfileViewModel : BaseViewModel
    {
        public UserProfileViewModel()
        {
			CommandAppearing = new Command((param) => OnAppearing(param));
			CommandButtonSave = new Command((param) => ButtonSaveClicked(param));
		}


        private UserProfile userProfile;
		private FirebaseAuth authUser;
		private string name;
		private string lastName;
		private bool isGenderChecked;
		private DateTime dateOfBirth;
		private string city;


		public string DisplayTitle => Localizator.Instance.SelectedLanguage.Profile;
		public string DisplayName => Localizator.Instance.SelectedLanguage.Name;
		public string DisplayLastName => Localizator.Instance.SelectedLanguage.LastName;
		public string DisplayCity => Localizator.Instance.SelectedLanguage.City;
		public string DisplayGender => Localizator.Instance.SelectedLanguage.Gender;
		public string DisplayDayOfBirth => Localizator.Instance.SelectedLanguage.DateOfBirth;
		public string DisplaySave => Localizator.Instance.SelectedLanguage.Save;
		public ICommand CommandAppearing { get; }
		public ICommand CommandButtonSave { get; }
		public string City
		{
			get => city;
			set
			{
				city = value;
				OnPropertyChanged();
			}
		}
		public DateTime DateOfBirth
		{
			get => dateOfBirth;
			set
			{
				dateOfBirth = value;
				OnPropertyChanged(nameof(dateOfBirth));
			}
		}
		public bool IsGenderChecked
		{
			get => isGenderChecked;
			set
			{
				isGenderChecked = value;
				OnPropertyChanged(nameof(isGenderChecked));
			}
		}
		public string LastName
		{
			get => lastName;
			set
			{
				lastName = value;
				OnPropertyChanged();
			}
		}
		public string Name
		{
			get => name;
			set
			{
				name = value;
				OnPropertyChanged(nameof(Name));
			}
		}

		private async void OnAppearing(object param)
		{
			OnPropertyChanged(null);

			authUser = await FBAuth.FireBaseAuth.GetProfileInfo();
			userProfile = await RealTimeDB.RealTimeDatabase.GetUser(authUser.User.Email);
			Name = userProfile.Name;
			LastName = userProfile.LastName;
			City = userProfile.City;
		}
		private async void ButtonSaveClicked(object param)
		{
			if (userProfile == null)
				return;
			userProfile.Name = Name;
			userProfile.LastName = LastName;
			userProfile.City = City;
			await RealTimeDB.RealTimeDatabase.PatchUser(userProfile);
		}
	}
}
