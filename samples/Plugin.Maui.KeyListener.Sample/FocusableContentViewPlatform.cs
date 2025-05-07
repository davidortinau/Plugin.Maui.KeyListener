#if IOS || MACCATALYST
using System.Threading.Tasks;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Core.Views;
using CommunityToolkit.Maui.Views;
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
		this.FocusGroupIdentifier = $"<{this.GetType().FullName}: {this.GetHashCode()}>";
    }

	// You don't really need to override this, if the user has enabled basic Keyboard navigation
	// through keyboard settings then this view will be focusable if you set the Semantic properties
	// If you set this to true, this will cause inconsistent behavior with native mac controls
	// For example, a UIButton can't be reached by a keyboard unless you've enabled keyboard navigation
	public override bool CanBecomeFocused => true;
	public override bool CanBecomeFirstResponder => true;

	public override void PressesBegan(NSSet<UIPress> presses, UIPressesEvent evt)
	{
		base.PressesBegan(presses, evt);

		/*
		just testing out modifying tab ordering
		foreach(var press in presses)
		{
			if (press.Key?.KeyCode == UIKeyboardHidUsage.KeyboardTab)
			{
				Superview.Subviews[0].BecomeFirstResponder();
			}
		}*/
	}



	public override void DidUpdateFocus(UIFocusUpdateContext context, UIFocusAnimationCoordinator coordinator)
    {
        base.DidUpdateFocus(context, coordinator);

        if (context.NextFocusedView == this)
        {
			if(CrossPlatformLayout is IView view)
			{
				view.IsFocused = true;
			}
		}
        else
        {
			if(CrossPlatformLayout is IView view)
			{
				view.IsFocused = false;
			}
		}
    }
}

#endif