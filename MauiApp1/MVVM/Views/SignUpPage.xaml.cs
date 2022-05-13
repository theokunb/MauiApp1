using MauiApp1.MVVM.Models;
using MauiApp1.MVVM.ViewModels;
using MauiApp1.Services;
using System.Text;

namespace MauiApp1;

public partial class SignUpPage : ContentPage
{
	public SignUpPage(SignUpViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}