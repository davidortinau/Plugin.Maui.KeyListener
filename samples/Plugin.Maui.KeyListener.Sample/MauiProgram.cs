using Microsoft.Extensions.DependencyInjection;
using Plugin.Maui.KeyListener;
using Microsoft.Maui.Handlers;
using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Core.Handlers;
using CommunityToolkit.Maui.Views;

namespace Plugin.Maui.KeyListener.Sample;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();

		builder
			.UseMauiApp<App>()
			.UseKeyListener()
			.UseMauiCommunityToolkit()
			.ConfigureMauiHandlers(handlers =>
			{
				#if IOS || MACCATALYST
				handlers.AddHandler(typeof(FocusableContentView), typeof(Plugin.Maui.KeyListener.Sample.FocusableContentViewPlatformHandler));

				/*SemanticOrderViewHandler.PlatformViewFactory = (handler) =>
				{
					if (handler.VirtualView is not SemanticOrderView)
					{
						return null;
					}

					var vc = new MauiSemanticOrderView2ViewController();
					var view = vc.View as MauiSemanticOrderView2;
					view.VirtualView2 = handler.VirtualView as SemanticOrderView;

					((Shell.Current.CurrentPage as ContentPage).Handler as IPlatformViewHandler)
						.ViewController?.AddChildViewController(vc);

					return view;
				};*/

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