using MauiApp1.MVVM.ViewModels;

namespace MauiApp1;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddSingleton<LoginViewModel>();
		builder.Services.AddTransient<SignUpViewModel>();
		builder.Services.AddSingleton<WorkViewModel>();
		builder.Services.AddSingleton<UserProfileViewModel>();

		builder.Services.AddSingleton<LoginPage>();
		builder.Services.AddTransient<SignUpPage>();
		builder.Services.AddSingleton<WorkPage>();
		builder.Services.AddSingleton<UserProfilePage>();

		var app = builder.Build();


		return app;
	}
}
