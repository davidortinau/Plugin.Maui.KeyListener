using Microsoft.Maui.Handlers;
using UIKit;

namespace Plugin.Maui.KeyListener.Sample;

public class NavigableContentViewHandler : ViewHandler<ContentView, UIView>
{
	public NavigableContentViewHandler() : base(ViewHandler.ViewMapper)
	{
	}

	protected override UIView CreatePlatformView()
	{
		return new FocusableContentUIView(); // Your custom UIView subclass
	}

	protected override void ConnectHandler(UIView platformView)
	{
		base.ConnectHandler(platformView);

		platformView.UserInteractionEnabled = true;
		platformView.BecomeFirstResponder(); // Optional if you want auto-focus
	}
}
