#if IOS || MACCATALYST
using System.Threading.Tasks;
using Foundation;
using Microsoft.Maui.Platform;
using UIKit;

namespace Plugin.Maui.KeyListener.Sample;

/// <summary>
/// The native implementation of the <see href="SemanticOrderView"/> control.
/// </summary>
public class FocusableContentViewPlatform : Microsoft.Maui.Platform.ContentView//, IUIKeyInput//, IUITextInputTraits
{

    public FocusableContentViewPlatform()
    {
        //UserInteractionEnabled = true;
    }

	public override bool CanBecomeFocused => true;
	public override bool CanBecomeFirstResponder => true;

    public override void DidUpdateFocus(UIFocusUpdateContext context, UIFocusAnimationCoordinator coordinator)
    {
        base.DidUpdateFocus(context, coordinator);

        if (context.NextFocusedView == this)
        {
			if(CrossPlatformLayout is IView view)
			{
				//BecomeFirstResponder();
				view.IsFocused = true;
			}
		}
        else
        {
			if(CrossPlatformLayout is IView view)
			{
				//ResignFirstResponder();
				view.IsFocused = false;
			}
		}
    }

	public override void TouchesBegan(NSSet touches, UIEvent evt)
    {
        base.TouchesBegan(touches, evt);
        // Ensure we become first responder when touched
        if (!IsFirstResponder)
		{
			//BecomeFirstResponder();
		}
	}
/*
	 bool IUIKeyInput.HasText => false;
    
    async void IUIKeyInput.InsertText(string text)
    {
        if (text == "\n" || text == "\r")
        {
            if(CrossPlatformLayout is VisualElement view)
			{
				await view.Window?.Page?.DisplayAlert("Tapped", "Tapped", "OK");
			}
        }
    }

    void IUIKeyInput.DeleteBackward() { }
	*/

	/*public UITextAutocapitalizationType AutocapitalizationType => UITextAutocapitalizationType.None;
    public UITextAutocorrectionType AutocorrectionType => UITextAutocorrectionType.No;
    public UITextSpellCheckingType SpellCheckingType => UITextSpellCheckingType.No;
    public UIKeyboardType KeyboardType => UIKeyboardType.Default;
    public UIReturnKeyType ReturnKeyType => UIReturnKeyType.Default;
    public bool EnablesReturnKeyAutomatically => false;
    public bool SecureTextEntry => false;*/
}

#endif