using Microsoft.Extensions.DependencyInjection;
using Plugin.Maui.KeyListener;
using Microsoft.Maui.Handlers;

namespace Plugin.Maui.KeyListener.Sample;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseKeyListener()
			.ConfigureMauiHandlers(handlers =>
			{
				#if IOS || MACCATALYST
				handlers.AddHandler(typeof(FocusableContentView), typeof(Plugin.Maui.KeyListener.Sample.FocusableContentViewPlatformHandler));
				#endif
			})
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddTransient<MainPage>();

		

		return builder.Build();
	}
}