#if IOS || MACCATALYST
using Microsoft.Maui.Handlers;
#endif

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
					if (handler is PageHandler pageHandler)
						handler.ViewController = new KeyboardPageViewController(handler.VirtualView, handler.MauiContext);
					return null; // Fall through to default view creation
				};
#endif
		});

		return builder;
	}
}