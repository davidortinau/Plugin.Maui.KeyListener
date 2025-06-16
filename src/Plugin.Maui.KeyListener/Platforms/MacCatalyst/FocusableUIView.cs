using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreGraphics;
using Foundation;
using UIKit;

namespace Plugin.Maui.KeyListener;

public class FocusableUIView : UIView
{
	public override bool CanBecomeFocused => true;  
	public override bool CanBecomeFirstResponder => true;  
	public override bool CanResignFirstResponder => true;  

	public FocusableUIView() : base()
	{
		Initialize();
	}

	public FocusableUIView(NSCoder coder) : base(coder)
	{
		Initialize();
	}

	public FocusableUIView(CGRect frame) : base(frame)
	{
		Initialize();
	}

	void Initialize()
	{
		UserInteractionEnabled = true;
	}

	public override void TouchesEnded(NSSet touches, UIEvent? evt)
	{
		this.BecomeFirstResponder();
		base.TouchesEnded(touches, evt);
	}
}