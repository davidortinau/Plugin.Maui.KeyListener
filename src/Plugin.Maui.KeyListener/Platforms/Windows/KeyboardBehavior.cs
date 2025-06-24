using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Input;

namespace Plugin.Maui.KeyListener;

public partial class KeyboardBehavior : PlatformBehavior<VisualElement>
{
	protected override void OnAttachedTo(VisualElement bindable, FrameworkElement platformView)
	{
		base.OnAttachedTo(bindable, platformView);

		ScopedElement = bindable;

		if (bindable.Handler?.PlatformView is UIElement content)
		{
			content.KeyDown += OnKeyDown;
			content.KeyUp += OnKeyUp;
		}
	}

	protected override void OnDetachedFrom(VisualElement bindable, FrameworkElement platformView)
	{
		base.OnDetachedFrom(bindable, platformView);

		if (bindable.Handler?.PlatformView is UIElement content)
		{
			content.KeyDown -= OnKeyDown;
			content.KeyUp -= OnKeyUp;
		}

		ScopedElement = null;
	}

	void OnKeyDown(object sender, KeyRoutedEventArgs e)
	{
		var eventArgs = e.ToKeyPressedEventArgs();
		RaiseKeyDown(eventArgs);
		if (eventArgs.Handled)
		{
			e.Handled = true;
		}
	}

	void OnKeyUp(object sender, KeyRoutedEventArgs e)
	{
		var eventArgs = e.ToKeyPressedEventArgs();
		RaiseKeyUp(eventArgs);
		if (eventArgs.Handled)
		{
			e.Handled = true;
		}
	}
}