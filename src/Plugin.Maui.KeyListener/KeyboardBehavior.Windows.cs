﻿#if WINDOWS
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugin.Maui.KeyListener;

public partial class KeyboardBehavior : PlatformBehavior<VisualElement>
{
	UIElement? _content;

	protected override void OnAttachedTo(VisualElement bindable, FrameworkElement platformView)
	{
		base.OnAttachedTo(bindable, platformView);

		var window = bindable.Window.Handler.PlatformView as Microsoft.UI.Xaml.Window;
		_content = window.Content;
		_content.KeyDown += OnKeyDown;
		_content.KeyUp += OnKeyUp;
		_content.PreviewKeyDown += OnPreviewKeyDown;
		_content.PreviewKeyUp += OnPreviewKeyUp;

		//platformView.KeyDown += OnKeyDown;
		//platformView.KeyUp += OnKeyUp;
		//platformView.PreviewKeyDown += OnPreviewKeyDown;
		//platformView.PreviewKeyUp += OnPreviewKeyUp;
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

		//platformView.KeyDown -= OnKeyDown;
		//platformView.KeyUp -= OnKeyUp;
		//platformView.PreviewKeyDown -= OnPreviewKeyDown;
		//platformView.PreviewKeyUp -= OnPreviewKeyUp;
	}

	void OnWindowKeyDown(object sender, Microsoft.UI.Xaml.Input.KeyRoutedEventArgs e)
	{
		Console.WriteLine($"OnWindowKeyDown {e.Key}");
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
		char keyChar = ((char)e.Key);
		var eventArgs = new KeyPressedEventArgs
		{
			Keys = e.Key.ToKeyboardKeys(),
			KeyChar = keyChar
		};
		this.RaiseKeyUp(eventArgs);
	}
}
#endif