#if ANDROID

using System.Diagnostics;
using Android.Views;
using Android.Widget;

namespace Plugin.Maui.KeyListener;

public partial class KeyboardBehavior : PlatformBehavior<VisualElement>
{
	/// <summary>
	/// Similarly to the Apple and Windows implementations, find the outermost layout to connect the key events to.
	/// </summary>
	private static Android.Views.View? GetParentLayout(Android.Views.View platformView)
	{
		Android.Views.View view = platformView;
		Android.Views.View? layout = null;
		while (view.Parent is Android.Views.View parent)
		{
			view = parent;
			// TODO: The outermost layout is a FrameLayout, but no KeyPress events get raised for it in MAUI.
			if (view is LinearLayout parentLayout)
				layout = parentLayout;
		}

		return layout;
	}

	protected override void OnAttachedTo(VisualElement bindable, Android.Views.View platformView)
	{
		base.OnAttachedTo(bindable, platformView);

		Android.Views.View? layout = GetParentLayout(platformView);
		if (layout is null)
			return;

		layout.KeyPress += OnKeyPress;
		layout.Focusable = true;
		layout.FocusableInTouchMode = true;
	}

	protected override void OnDetachedFrom(VisualElement bindable, Android.Views.View platformView)
	{
		platformView.KeyPress -= OnKeyPress;

		base.OnDetachedFrom(bindable, platformView);
	}

	void OnKeyPress(object? sender, Android.Views.View.KeyEventArgs e)
	{
		if (e.Event is not KeyEvent @event)
			return;

		var args = new KeyPressedEventArgs
		{
			Keys = @event.KeyCode.ToKeyboardKeys(),
			Modifiers = KeyboardModifiersExtensions.ToKeyboardModifiers(@event.MetaState),
			KeyChar = char.ToUpper((char)@event.UnicodeChar)
		};

		switch (@event.Action)
		{
			case KeyEventActions.Down:
				RaiseKeyDown(args);
				break;
			case KeyEventActions.Up:
				RaiseKeyUp(args);
				break;
		}
	}
}
#endif
