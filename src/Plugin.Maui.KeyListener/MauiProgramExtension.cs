using Plugin.Maui.KeyListener;
using Microsoft.Maui.Handlers;

namespace Plugin.Maui.KeyListener;
public static class MauiProgramExtensions
{
	public static MauiAppBuilder UseKeyListener(this MauiAppBuilder builder)
	{
		builder.ConfigureMauiHandlers(handlers =>
		{
			#if IOS || MACCATALYST
				PageHandler.PlatformViewFactory = (handler) =>
				{
					if (handler is not PageHandler pageHandler)
						return null;
						
					var vc = new KeyboardPageViewController(handler.VirtualView, handler.MauiContext);
					handler.ViewController = vc;
					return (Microsoft.Maui.Platform.ContentView)vc.View.Subviews[0];
				};
			#endif
		});

		return builder;
	}
}