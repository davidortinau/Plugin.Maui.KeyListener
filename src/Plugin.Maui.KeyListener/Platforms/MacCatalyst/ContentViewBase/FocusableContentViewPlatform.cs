using UIKit;
using ContentView = Microsoft.Maui.Platform.ContentView;

namespace Plugin.Maui.KeyListener;

public class FocusableContentViewPlatform : ContentView
{
	public FocusableContentViewPlatform()
	{
		FocusGroupIdentifier = $"<{GetType().FullName}: {GetHashCode()}>";
	}

	// You don't really need to override this, if the user has enabled basic Keyboard navigation
	// through keyboard settings then this view will be focusable if you set the Semantic properties
	// If you set this to true, this will cause inconsistent behavior with native mac controls
	// For example, a UIButton can't be reached by a keyboard unless you've enabled keyboard navigation
	public override bool CanBecomeFocused => true;
	public override bool CanBecomeFirstResponder => true;


	public override void DidUpdateFocus(UIFocusUpdateContext context, UIFocusAnimationCoordinator coordinator)
	{
		base.DidUpdateFocus(context, coordinator);

		if (context.NextFocusedView == this)
		{
			if (CrossPlatformLayout is IView view)
			{
				view.IsFocused = true;
			}
		}
		else
		{
			if (CrossPlatformLayout is IView view)
			{
				view.IsFocused = false;
			}
		}
	}
}