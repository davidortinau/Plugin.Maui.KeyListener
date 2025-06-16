using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIKit;

namespace Plugin.Maui.KeyListener;

public class FocusableContentUIView : UIView
{
	public override bool CanBecomeFocused => true;  // Allow keyboard focus:contentReference[oaicite:7]{index=7}
	public override bool CanBecomeFirstResponder => true;  // Allow receiving key events
	public override bool CanResignFirstResponder => true;  // (optional override)

	public FocusableContentUIView()
	{
		UserInteractionEnabled = true; // Enable mouse interaction
		// You may also set any needed Accessibility properties here (e.g., IsAccessibilityElement) if relevant.
	}

	// Override focus update to apply custom visual styling when focus changes
	public override void DidUpdateFocus(UIFocusUpdateContext context, UIFocusAnimationCoordinator coordinator)
	{
		base.DidUpdateFocus(context, coordinator);
		if (context.NextFocusedView == this)
		{
			// This view just gained focus – apply a focus visual (e.g., change background or border)
			//this.Layer.BorderColor = UIColor.SystemBlueColor.CGColor;
			//this.Layer.BorderWidth = 2;
		}
		if (context.PreviouslyFocusedView == this)
		{
			// This view lost focus – remove the focus styling
			//this.Layer.BorderWidth = 0;
		}
	}
}