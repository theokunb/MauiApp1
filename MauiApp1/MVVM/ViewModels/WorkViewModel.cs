using MauiApp1.Helpers;
using MauiApp1.MVVM.Models;
using System.Windows.Input;

namespace MauiApp1.MVVM.ViewModels
{
    public class WorkViewModel : BaseViewModel
    {
        public WorkViewModel()
        {
            CommandBack = new Command((param) => BackClicked(param));
            CommandAppearing = new Command((param) => OnAppearing(param));
        }


        public string DisplayTitle => Localizator.Instance.SelectedLanguage.Main;
        public string DisplayLogOut => Localizator.Instance.SelectedLanguage.LogOut;
        public ICommand CommandBack { get; }
        public ICommand CommandAppearing { get; }


        private async void BackClicked(object param)
        {
            var dialogResult = await Shell.Current.DisplayAlert(Localizator.Instance.SelectedLanguage.Warning, Localizator.Instance.SelectedLanguage.DoYouReallyWantToLeave, Localizator.Instance.SelectedLanguage.Yes, Localizator.Instance.SelectedLanguage.No);
            if (!dialogResult)
                return;
            Preferences.Remove(Strings.AuthToken);
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
        private void OnAppearing(object param)
        {
            OnPropertyChanged(null);
        }
    }
}
