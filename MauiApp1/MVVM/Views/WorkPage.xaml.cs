using MauiApp1.Helpers;
using MauiApp1.MVVM.Models;
using MauiApp1.MVVM.ViewModels;

namespace MauiApp1;

public partial class WorkPage : ContentPage
{
	public WorkPage(WorkViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}