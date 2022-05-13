using MauiApp1.Helpers;
using MauiApp1.MVVM.Models;
using MauiApp1.MVVM.ViewModels;
using MauiApp1.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MauiApp1;

public partial class LoginPage : ContentPage, INotifyPropertyChanged
{
	public LoginPage(LoginViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

}