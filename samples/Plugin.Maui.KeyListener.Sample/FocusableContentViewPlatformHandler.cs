#if IOS || MACCATALYST
using Foundation;
using Microsoft.Maui.Platform;
using UIKit;


namespace Plugin.Maui.KeyListener.Sample;

public class FocusableContentViewPlatformHandler : Microsoft.Maui.Handlers.ContentViewHandler
{
	public FocusableContentViewPlatformHandler()
	{
	}

	protected override Microsoft.Maui.Platform.ContentView CreatePlatformView()
	{
		return new FocusableContentViewPlatform();
	}

}
#endif