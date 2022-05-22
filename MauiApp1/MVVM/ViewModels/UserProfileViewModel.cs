using Firebase.Auth;
using MauiApp1.Helpers;
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
			imageCollection = new List<UserImage>();
			CommandAppearing = new Command((param) => OnAppearing(param));
			CommandButtonSave = new Command((param) => ButtonSaveClicked(param));
			CommandAddImage = new Command((param) => ButtonAddClicked(param));
			CommandRemoveImage = new Command(param => ButtonRemoveClicked(param));
		}


        private UserProfile userProfile;
		private FirebaseAuth authUser;
		private string name;
		private string lastName;
		private bool isGenderChecked;
		private DateTime dateOfBirth;
		private string city;
		private IList<UserImage> imageCollection;

		public string DisplayTitle => Localizator.Instance.SelectedLanguage.Profile;
		public string DisplayName => Localizator.Instance.SelectedLanguage.Name;
		public string DisplayLastName => Localizator.Instance.SelectedLanguage.LastName;
		public string DisplayCity => Localizator.Instance.SelectedLanguage.City;
		public string DisplayGender => Localizator.Instance.SelectedLanguage.Gender;
		public string DisplayDayOfBirth => Localizator.Instance.SelectedLanguage.DateOfBirth;
		public string DisplaySave => Localizator.Instance.SelectedLanguage.Save;
		public ICommand CommandAppearing { get; }
		public ICommand CommandButtonSave { get; }
		public ICommand CommandAddImage { get; }
		public ICommand CommandRemoveImage { get; }
		public IList<UserImage> ImageCollection
        {
			get=> imageCollection;
            set
            {
				imageCollection = value;
				OnPropertyChanged();
            }
        }
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

			await Task.Factory.StartNew(async() =>
			{
				authUser = await FBAuth.FireBaseAuth.GetProfileInfo();
				userProfile = await RealTimeDB.RealTimeDatabase.GetUser(authUser.User.Email);
				Name = userProfile.Name;
				LastName = userProfile.LastName;
				City = userProfile.City;
				ImageCollection = userProfile.Images;
			});
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
        private async void ButtonAddClicked(object param)
        {
			var file = await MediaPicker.PickPhotoAsync();
			if (file == null)
				return;

			var uploadTask = await FBStorage.Storage.PutDocument(Strings.StorageUserImages, file);
			var link = await uploadTask;

			userProfile.Images.Add(new UserImage()
			{
				Title = file.FileName,
				ImagePath = link
			});
			ImageCollection = userProfile.Images;
            await RealTimeDB.RealTimeDatabase.PatchUser(userProfile);
        }
        private async void ButtonRemoveClicked(object param)
        {
            if(param is UserImage userImage)
            {
				var dialogResult = await Shell.Current.DisplayAlert(Localizator.Instance.SelectedLanguage.Warning,
					Localizator.Instance.SelectedLanguage.DeleteSelectedImage,
					Localizator.Instance.SelectedLanguage.Yes,
					Localizator.Instance.SelectedLanguage.No);
				if (!dialogResult)
					return;
				userProfile.Images.Remove(userImage);
                ImageCollection = userProfile.Images;
            }
        }
    }
}
