using Firebase.Auth;
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
    public class UserProfileViewModel : BaseViewModel
    {
        public UserProfileViewModel()
        {
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
		public ObservableCollection<UserImage> ImageCollection { get; set; } = new ObservableCollection<UserImage>();
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
			await Task.Factory.StartNew(async() =>
			{
				IsBusy = true;
				for(int i = 0; i < 6; i++)
					ImageCollection.Add(new UserImage());
				authUser = await FBAuth.FireBaseAuth.GetProfileInfo();
				userProfile = await RealTimeDB.RealTimeDatabase.GetUser(authUser.User.Email);
				Name = userProfile.Name;
				LastName = userProfile.LastName;
				City = userProfile.City;
				if (userProfile.Images.Count != 0)
					for(int i = 0; i < userProfile.Images.Count; i++)
						ImageCollection[i] = userProfile.Images[i];
                OnPropertyChanged(null);
				IsBusy = false;
            });
		}
		private async void ButtonSaveClicked(object param)
		{
			if (IsBusy)
				return;
			IsBusy = true;
			if (userProfile == null)
				return;
			userProfile.Name = Name;
			userProfile.LastName = LastName;
			userProfile.City = City;
			await RealTimeDB.RealTimeDatabase.PatchUser(userProfile);
			IsBusy = false;
        }
        private async void ButtonAddClicked(object param)
        {
			if (param is not UserImage userImage)
				return;
			if (IsBusy)
				return;
			IsBusy = true;
            var idEditableImage = ImageCollection.IndexOf(userImage);
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
			ImageCollection[idEditableImage] = userProfile.Images.Last();
            await RealTimeDB.RealTimeDatabase.PatchUser(userProfile);
			IsBusy = false;
        }
        private async void ButtonRemoveClicked(object param)
        {
			if (IsBusy)
				return;
			IsBusy = true;
            if(param is UserImage userImage)
            {
				var idRemovableImage = ImageCollection.IndexOf(userImage);
				var dialogResult = await Shell.Current.DisplayAlert(Localizator.Instance.SelectedLanguage.Warning,
					Localizator.Instance.SelectedLanguage.DeleteSelectedImage,
					Localizator.Instance.SelectedLanguage.Yes,
					Localizator.Instance.SelectedLanguage.No);
				if (!dialogResult)
					return;
				userProfile.Images.Remove(userImage);
				ImageCollection[idRemovableImage] = new UserImage();

				await FBStorage.Storage.RemoveDocument(Strings.StorageUserImages, userImage.Title);
				await RealTimeDB.RealTimeDatabase.PatchUser(userProfile);
            }
			IsBusy = false;
        }
    }
}
