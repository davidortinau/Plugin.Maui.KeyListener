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
#if MACCATALYST
				handlers.AddHandler(typeof(FocusableContentView), typeof(FocusableContentViewPlatformHandler));
#endif
			})
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddTransient<MainPage>();

#if MACCATALYST
		builder.ConfigureMauiHandlers(handlers =>
		{
			handlers.AddHandler(typeof(NavigableContentView), typeof(NavigableContentViewHandler));
		});
#endif

		return builder.Build();
	}
}