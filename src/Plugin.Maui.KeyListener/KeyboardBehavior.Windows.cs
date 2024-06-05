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

	// See: https://github.com/CommunityToolkit/Maui/issues/1912
	private List<Guid> _boundIds = [Guid.Empty];

	protected override void OnAttachedTo(VisualElement bindable, FrameworkElement platformView)
	{
		// Handle case where element is bound multiple times, we only allow a single binding for this behavior
		if (_boundIds.Contains(bindable?.Id ?? Guid.Empty)) { return; }
		_boundIds.Add(bindable.Id);

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

		base.OnAttachedTo(bindable, platformView);
	}

	protected override void OnDetachedFrom(VisualElement bindable, FrameworkElement platformView)
	{
		if ((bindable?.Id ?? Guid.Empty) != Guid.Empty && _boundIds.Contains(bindable.Id)) { _boundIds.Remove(bindable.Id); }

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

		base.OnDetachedFrom(bindable, platformView);
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