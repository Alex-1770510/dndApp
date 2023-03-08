using first.Database;
using first.Views;

namespace first;

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

		//for db
        builder.Services.AddSingleton<AllProfs>();
        builder.Services.AddTransient<ProfileView>();

        builder.Services.AddSingleton<CharProfDatabase>();
		//for db end

        return builder.Build();
	}
}
