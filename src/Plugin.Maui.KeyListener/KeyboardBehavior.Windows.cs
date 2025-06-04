#if WINDOWS
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Window = Microsoft.UI.Xaml.Window;

namespace Plugin.Maui.KeyListener;

public partial class KeyboardBehavior : PlatformBehavior<VisualElement>
{
	UIElement? _content;

	protected override void OnAttachedTo(VisualElement bindable, FrameworkElement platformView)
	{
		base.OnAttachedTo(bindable, platformView);

		var window = bindable?.Window?.Handler?.PlatformView as Microsoft.UI.Xaml.Window;

		if (window == null)
			return;

		if (bindable.Handler?.PlatformView is UIElement content)
		{
			_content = content;
			_content.KeyDown += OnKeyDown;
			_content.KeyUp += OnKeyUp;
			_content.PreviewKeyDown += OnPreviewKeyDown;
			_content.PreviewKeyUp += OnPreviewKeyUp;
		}
	}

	protected override void OnDetachedFrom(VisualElement bindable, FrameworkElement platformView)
	{
		base.OnDetachedFrom(bindable, platformView);

		if (_content is null)
			return;

		_content.KeyDown -= OnKeyDown;
		_content.KeyUp -= OnKeyUp;
		_content.PreviewKeyDown -= OnPreviewKeyDown;
		_content.PreviewKeyUp -= OnPreviewKeyUp;
		_content = null;
	}

	void OnWindowKeyDown(object sender, Microsoft.UI.Xaml.Input.KeyRoutedEventArgs e)
	{
		Console.WriteLine($"OnWindowKeyDown {e.Key}");
	}

	void OnKeyDown(object sender, Microsoft.UI.Xaml.Input.KeyRoutedEventArgs e)
	{
		var eventArgs = e.ToKeyPressedEventArgs();
		this.RaiseKeyDown(eventArgs);
		if (eventArgs.Handled)
			e.Handled = true;
	}
	void OnPreviewKeyUp(object sender, Microsoft.UI.Xaml.Input.KeyRoutedEventArgs e)
	{
		Console.WriteLine($"OnPreviewKeyUp {e.Key}");
	}

	void OnPreviewKeyDown(object sender, Microsoft.UI.Xaml.Input.KeyRoutedEventArgs e)
	{
		Console.WriteLine($"OnPreviewKeyDown {e.Key}");
	}

	void OnKeyUp(object sender, Microsoft.UI.Xaml.Input.KeyRoutedEventArgs e)
	{
		var eventArgs = e.ToKeyPressedEventArgs();
		this.RaiseKeyUp(eventArgs);
		if (eventArgs.Handled)
			e.Handled = true;
	}
}
#endif