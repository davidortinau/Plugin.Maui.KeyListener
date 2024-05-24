#if WINDOWS
using Microsoft.UI.Xaml;

namespace Plugin.Maui.KeyListener;

public partial class KeyboardBehavior : PlatformBehavior<VisualElement>
{
	public KeyboardBehavior()
	{
		// We prefer preview events on Windows
		UsePreviewEvents = true;
	}

	protected override void OnAttachedTo(VisualElement bindable, FrameworkElement platformView)
	{
		base.OnAttachedTo(bindable, platformView);

		if (UsePreviewEvents)
		{
			platformView.PreviewKeyDown += OnPreviewKeyDown;
			platformView.PreviewKeyUp += OnPreviewKeyUp;
		}
		else
		{
			platformView.KeyDown += OnKeyDown;
			platformView.KeyUp += OnKeyUp;
		}
	}

	protected override void OnDetachedFrom(VisualElement bindable, FrameworkElement platformView)
	{
		base.OnDetachedFrom(bindable, platformView);

		if (UsePreviewEvents)
		{
			platformView.PreviewKeyDown -= OnPreviewKeyDown;
			platformView.PreviewKeyUp -= OnPreviewKeyUp;
		}
		else
		{
			platformView.KeyDown -= OnKeyDown;
			platformView.KeyUp -= OnKeyUp;
		}
	}

	void OnPreviewKeyDown(object sender, Microsoft.UI.Xaml.Input.KeyRoutedEventArgs e)
	{
		char keyChar = ((char)e.Key);
		var eventArgs = new KeyPressedEventArgs
		{
			Key = e.Key.ToKeyboardKey(),
			KeyChar = keyChar
		};

		this.RaiseKeyDown(eventArgs);

		e.Handled = eventArgs.Handled;
	}

	void OnKeyDown(object sender, Microsoft.UI.Xaml.Input.KeyRoutedEventArgs e)
	{
		char keyChar = ((char)e.Key);
		var eventArgs = new KeyPressedEventArgs
		{
			Key = e.Key.ToKeyboardKey(),
			KeyChar = keyChar
		};

		this.RaiseKeyDown(eventArgs);

		e.Handled = eventArgs.Handled;
	}

	void OnPreviewKeyUp(object sender, Microsoft.UI.Xaml.Input.KeyRoutedEventArgs e)
	{
		char keyChar = ((char)e.Key);
		var eventArgs = new KeyPressedEventArgs
		{
			Key = e.Key.ToKeyboardKey(),
			KeyChar = keyChar
		};

		this.RaiseKeyUp(eventArgs);
		e.Handled = eventArgs.Handled;
	}

	void OnKeyUp(object sender, Microsoft.UI.Xaml.Input.KeyRoutedEventArgs e)
	{
		char keyChar = ((char)e.Key);
		var eventArgs = new KeyPressedEventArgs
		{
			Key = e.Key.ToKeyboardKey(),
			KeyChar = keyChar
		};
		this.RaiseKeyUp(eventArgs);
		e.Handled = eventArgs.Handled;
	}
}
#endif