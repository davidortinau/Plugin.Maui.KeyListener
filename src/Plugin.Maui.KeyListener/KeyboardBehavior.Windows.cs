#if WINDOWS
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Input;

namespace Plugin.Maui.KeyListener;

public partial class KeyboardBehavior : PlatformBehavior<VisualElement>
{
	protected override void OnAttachedTo(VisualElement bindable, FrameworkElement platformView)
	{
		base.OnAttachedTo(bindable, platformView);

		if (platformView.XamlRoot?.Content is FrameworkElement content)
		{
			content.KeyDown += OnKeyDown;
			content.KeyUp += OnKeyUp;
		}
	}

	protected override void OnDetachedFrom(VisualElement bindable, FrameworkElement platformView)
	{
		if (platformView.XamlRoot?.Content is FrameworkElement content)
		{
			content.KeyDown -= OnKeyDown;
			content.KeyUp -= OnKeyUp;
		}

		base.OnDetachedFrom(bindable, platformView);
	}

	void OnKeyDown(object sender, KeyRoutedEventArgs e)
	{
		var eventArgs = e.ToKeyPressedEventArgs();
		RaiseKeyDown(eventArgs);
		if (eventArgs.Handled)
			e.Handled = true;
	}

	void OnKeyUp(object sender, KeyRoutedEventArgs e)
	{
		var eventArgs = e.ToKeyPressedEventArgs();
		RaiseKeyUp(eventArgs);
		if (eventArgs.Handled)
			e.Handled = true;
	}
}
#endif