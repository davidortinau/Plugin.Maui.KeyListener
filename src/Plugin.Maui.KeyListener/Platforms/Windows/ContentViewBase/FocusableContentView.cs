using Microsoft.Maui.Controls;
using Microsoft.UI.Xaml;

namespace Plugin.Maui.KeyListener;

public partial class FocusableContentView : ContentView
{
	partial void OnPlatformLoaded(object sender, EventArgs e)
    {
		if (Handler?.PlatformView is FrameworkElement nativeElement)
		{
			nativeElement.IsTabStop = true;
		}
    }

	partial void OnPlatformFocused(object sender, FocusEventArgs e)
    {
	    return;
    }
}

