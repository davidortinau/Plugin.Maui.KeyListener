using Foundation;
using UIKit;

namespace Plugin.Maui.KeyListener.Sample;

public class FocusableUIView : UIView
{
	public FocusableUIView()
	{
		UserInteractionEnabled = true;
	}

	public override bool CanBecomeFirstResponder => true;

	public override void TouchesEnded(NSSet touches, UIEvent? evt)
	{
		base.TouchesEnded(touches, evt);
		BecomeFirstResponder(); // Trigger focus on click
	}
}
