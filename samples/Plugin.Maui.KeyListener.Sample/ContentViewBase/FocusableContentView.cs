using Microsoft.Maui.Controls;

#if MACCATALYST
using UIKit;
#endif
namespace Plugin.Maui.KeyListener.Sample;

public class FocusableContentView : ContentView
{
    public FocusableContentView()
    {
        this.Focused += OnFocused;
        this.GestureRecognizers.Add(new TapGestureRecognizer
        {
            NumberOfTapsRequired = 1,
            Command = new Command(async () =>
            {
                await this.Window.Page.DisplayAlert("Tapped", "Tapped", "OK");
                Focus();
            })
        });


        AutomationProperties.SetIsInAccessibleTree(this, true);
}

	void OnFocused(object sender, FocusEventArgs e)
	{

	}


	protected override void OnHandlerChanged()
	{
		base.OnHandlerChanged();

#if MACCATALYST
		if (Handler?.PlatformView is UIView nativeView)
		{
			nativeView.IsAccessibilityElement = true;
			//nativeView.AccessibilityLabel = "Focusable content view for accessibility.";
			//nativeView.AccessibilityTraits = UIAccessibilityTrait.Button;

			nativeView.UserInteractionEnabled = true;

			// Make it the first responder to test focus
			nativeView.BecomeFirstResponder();
		}
#endif
	}
}

