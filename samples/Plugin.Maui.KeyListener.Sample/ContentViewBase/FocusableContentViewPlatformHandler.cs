#if MACCATALYST
using Microsoft.Maui.Handlers;
using ContentView = Microsoft.Maui.Platform.ContentView;

namespace Plugin.Maui.KeyListener.Sample;

public class FocusableContentViewPlatformHandler : ContentViewHandler
{
	protected override ContentView CreatePlatformView()
	{
		return new FocusableContentViewPlatform();
	}
}
#endif