using Microsoft.Maui.Handlers;
using Microsoft.Maui.Controls;
using UIKit;

namespace Plugin.Maui.KeyListener.Sample;

public class NavigableContentViewHandler : ViewHandler<ContentView, UIView>
{
	public static IPropertyMapper<ContentView, NavigableContentViewHandler> Mapper =
		new PropertyMapper<ContentView, NavigableContentViewHandler>(ViewHandler.ViewMapper);

	public NavigableContentViewHandler() : base(Mapper) { }

	protected override UIView CreatePlatformView()
	{
		return new FocusableUIView();
	}
}