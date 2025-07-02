using Microsoft.Maui.Controls;
#if WINDOWS
using Microsoft.UI.Xaml;
#endif
#if MACCATALYST
using UIKit;
#endif
namespace Plugin.Maui.KeyListener;

public partial class FocusableContentView : ContentView
{
    public void OnPlatformLoaded(object? sender, EventArgs e)
    {
	    if (Handler?.PlatformView is UIView nativeView)
	    {
		    nativeView.IsAccessibilityElement = true;
		    nativeView.UserInteractionEnabled = true;
	    }
    }

	public void OnPlatformFocused(object sender, FocusEventArgs e)
	{
		if (Handler?.PlatformView is UIView nativeView)
		{
			nativeView.BecomeFirstResponder();
		}
	}

	protected override void OnHandlerChanged()
	{
		base.OnHandlerChanged();

		if (Handler?.PlatformView is UIView nativeView)
		{
			nativeView.IsAccessibilityElement = true;
			nativeView.UserInteractionEnabled = true;
			nativeView.BecomeFirstResponder();
		}
	}
}

