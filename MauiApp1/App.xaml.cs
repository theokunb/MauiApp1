using MauiApp1.Helpers;
using MauiApp1.MVVM.Models;
using MauiApp1.Services;
using System.Collections.ObjectModel;

namespace MauiApp1;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		ObservableCollection<Language> Languages = new ObservableCollection<Language>();
		Localizator localizator = Localizator.Instance;
		foreach (var element in localizator.Languages)
		{
			Languages.Add(element);
		}


		MainPage = new AppShell();
    }
}
