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

		var contentPanel = bindable is Page
						 ? bindable.Handler.PlatformView as Microsoft.Maui.Platform.ContentPanel
						 : (bindable.Window.Handler.PlatformView as Microsoft.UI.Xaml.Window).Content;

		//var window = bindable.Window.Handler.PlatformView as Microsoft.UI.Xaml.Window;

		if (UsePreviewEvents)
		{
			contentPanel.PreviewKeyDown += OnPreviewKeyDown;
			contentPanel.PreviewKeyUp += OnPreviewKeyUp;
		}
		else
		{
			contentPanel.KeyDown += OnKeyDown;
			contentPanel.KeyUp += OnKeyUp;
		}
	}

	protected override void OnDetachedFrom(VisualElement bindable, FrameworkElement platformView)
	{
		base.OnDetachedFrom(bindable, platformView);

		var contentPanel = bindable is Page 
						 ? bindable.Handler.PlatformView as Microsoft.Maui.Platform.ContentPanel
						 : (bindable.Window.Handler.PlatformView as Microsoft.UI.Xaml.Window).Content;
		//var window = bindable.Window.Handler.PlatformView as Microsoft.UI.Xaml.Window;

		if (UsePreviewEvents)
		{
			contentPanel.PreviewKeyDown -= OnPreviewKeyDown;
			contentPanel.PreviewKeyUp -= OnPreviewKeyUp;
		}
		else
		{
			contentPanel.KeyDown -= OnKeyDown;
			contentPanel.KeyUp -= OnKeyUp;
		}
	}

	void OnPreviewKeyDown(object sender, Microsoft.UI.Xaml.Input.KeyRoutedEventArgs e)
	{
		char keyChar = ((char)e.Key);
		var eventArgs = new KeyPressedEventArgs
		{
			Keys = e.Key.ToKeyboardKeys(),
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
			Keys = e.Key.ToKeyboardKeys(),
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
			Keys = e.Key.ToKeyboardKeys(),
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
			Keys = e.Key.ToKeyboardKeys(),
			KeyChar = keyChar
		};
		this.RaiseKeyUp(eventArgs);
		e.Handled = eventArgs.Handled;
	}
}
#endif