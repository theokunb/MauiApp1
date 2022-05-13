using Firebase.Auth;
using MauiApp1.MVVM.Models;
using MauiApp1.MVVM.ViewModels;
using MauiApp1.Services;

namespace MauiApp1;

public partial class UserProfilePage : ContentPage
{
	public UserProfilePage(UserProfileViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}