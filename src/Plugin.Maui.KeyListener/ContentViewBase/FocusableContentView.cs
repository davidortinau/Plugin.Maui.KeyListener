using Microsoft.Maui.Controls;
#if WINDOWS
using Microsoft.UI.Xaml;
#endif
#if MACCATALYST
using UIKit;
#endif
namespace Plugin.Maui.KeyListener;

public class FocusableContentView : ContentView
{
    public FocusableContentView()
    {
        this.Focused += OnFocused;
        Loaded += OnLoaded;

        this.GestureRecognizers.Add(new TapGestureRecognizer
        {
            NumberOfTapsRequired = 1,
            Command = new Command(async () =>
            {
                Focus();
            })
        });

        //The control will not get keyboard focus without this.
        AutomationProperties.SetIsInAccessibleTree(this, true);
	}
    
    void OnLoaded(object? sender, EventArgs e)
    {
#if WINDOWS
		if (Handler?.PlatformView is FrameworkElement nativeElement)
		{
			nativeElement.IsTabStop = true;
		}
#endif
#if MACCATALYST
	    if (Handler?.PlatformView is UIView nativeView)
	    {
		    nativeView.IsAccessibilityElement = true;
		    nativeView.UserInteractionEnabled = true;
		    //nativeView.BecomeFirstResponder();
	    }
#endif 
	    Loaded -= OnLoaded;
    }

	void OnFocused(object sender, FocusEventArgs e)
	{
#if MACCATALYST
		if (Handler?.PlatformView is UIView nativeView)
		{
			//nativeView.UserInteractionEnabled = true;
			nativeView.BecomeFirstResponder();
		}
#endif
	}

	protected override void OnHandlerChanged()
	{
		base.OnHandlerChanged();

#if MACCATALYST
		if (Handler?.PlatformView is UIView nativeView)
		{
			nativeView.IsAccessibilityElement = true;
			nativeView.UserInteractionEnabled = true;
			nativeView.BecomeFirstResponder();
		}
#endif
	}
}

