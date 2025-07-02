using Microsoft.Maui.Controls;
using Microsoft.UI.Xaml;

namespace Plugin.Maui.KeyListener;

public partial class FocusableContentView : ContentView
{
    public void OnPlatformLoaded(object? sender, EventArgs e)
    {
		if (Handler?.PlatformView is FrameworkElement nativeElement)
		{
			nativeElement.IsTabStop = true;
		}
    }

    public void OnPlatformFocused(object sender, FocusEventArgs e)
    {
	    return;
    }

}

