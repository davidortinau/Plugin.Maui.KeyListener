namespace Plugin.Maui.KeyListener;

/// <summary>
/// Keyboard behavior to intercept keypresses events on mac and windows platforms
/// </summary>
public partial class KeyboardBehavior : PlatformBehavior<VisualElement>
{
	private KeyboardBehaviorTriggers _triggers;

	/// <summary>
	/// The element that received the keypress event.  Needed for determining scope
	/// </summary>
	public VisualElement ScopedElement { get; private set; }

	/// <summary>
	/// Behaviors have triggers.  In this implementation they are not used, but required.  Using the trigger in the declaration will
	/// currently throw a not implemented exception.
	/// </summary>
	public KeyboardBehaviorTriggers Triggers => _triggers ??= new KeyboardBehaviorTriggers();

	/// <summary>
	/// Event raised when the key is pressed down.
	/// </summary>
	public event EventHandler<KeyPressedEventArgs>? KeyDown;

	/// <summary>
	/// Event raised when the key is released.
	/// </summary>
	public event EventHandler<KeyPressedEventArgs>? KeyUp;

	internal void RaiseKeyDown(KeyPressedEventArgs args)
	{
		KeyDown?.Invoke(this, args);
	}

	internal void RaiseKeyUp(KeyPressedEventArgs args)
	{
		KeyUp?.Invoke(this, args);
	}
}