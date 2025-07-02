namespace Plugin.Maui.KeyListener;

using Microsoft.Maui.Controls;
using UIKit;


public partial class FocusableContentView : ContentView
{
    partial void OnPlatformLoaded(object sender, EventArgs e)
    {
	    if (Handler?.PlatformView is UIView nativeView)
	    {
		    nativeView.IsAccessibilityElement = true;
		    nativeView.UserInteractionEnabled = true;
	    }
    }

	partial void OnPlatformFocused(object sender, FocusEventArgs e)
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

