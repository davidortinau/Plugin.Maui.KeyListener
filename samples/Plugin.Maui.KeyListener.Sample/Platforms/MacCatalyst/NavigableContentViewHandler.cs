using Microsoft.Maui.Handlers;
using UIKit;
using Microsoft.Maui.Controls;
using Microsoft.Maui;

namespace Plugin.Maui.KeyListener.Sample;

public class NavigableContentViewHandler : ViewHandler<ContentView, UIView>
{
	public static IPropertyMapper<ContentView, NavigableContentViewHandler> Mapper =
		new PropertyMapper<ContentView, NavigableContentViewHandler>(ViewHandler.ViewMapper);

	public NavigableContentViewHandler() : base(Mapper)
	{
	}

	protected override UIView CreatePlatformView()
	{
		return new FocusableUIView();
	}

	protected override void ConnectHandler(UIView platformView)
	{
		base.ConnectHandler(platformView);
		platformView.UserInteractionEnabled = true;
	}
}
