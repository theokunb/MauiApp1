using MauiApp1.Helpers;

namespace MauiApp1;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
		var lastToken = Preferences.Get(Strings.AuthToken, string.Empty);
		if (string.IsNullOrEmpty(lastToken))
			Shell.Current.GoToAsync($"{nameof(LoginPage)}");
		else
			Shell.Current.GoToAsync($"{nameof(WorkPage)}");
	}
}