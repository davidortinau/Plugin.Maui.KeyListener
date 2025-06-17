//using Microsoft.Maui.Controls;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using UIKit;

namespace Plugin.Maui.KeyListener.Sample;

public class NavigableContentViewHandler : ViewHandler<Microsoft.Maui.Controls.ContentView, UIView>
{
	public static IPropertyMapper<Microsoft.Maui.Controls.ContentView, NavigableContentViewHandler> Mapper =
		new PropertyMapper<Microsoft.Maui.Controls.ContentView, NavigableContentViewHandler>(ViewHandler.ViewMapper);

	protected FocusableUIView? focusableView;

	public NavigableContentViewHandler() : base(Mapper) { }

	protected override UIView CreatePlatformView()
	{
		focusableView = new FocusableUIView();
		return focusableView;
	}

	protected override void ConnectHandler(UIView platformView)
	{
		base.ConnectHandler(platformView);
		UpdateContent();
	}

	public override void SetVirtualView(IView view)
	{
		base.SetVirtualView(view);
		UpdateContent();
	}

	protected void UpdateContent()
	{
		if (focusableView == null || VirtualView?.Content == null)
		{
			return;
		}

		// Remove previous subviews
		foreach (var subview in focusableView.Subviews)
		{
			subview.RemoveFromSuperview();
		}

		// Ensure the handler is created
		var content = VirtualView.Content;
		if (content.Handler == null)
		{
			content.ToHandler(MauiContext!);
		}

		if (content.Handler?.PlatformView is UIView contentView)
		{
			contentView.Frame = focusableView.Bounds;
			contentView.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight;
			focusableView.AddSubview(contentView);
		}
	}
}