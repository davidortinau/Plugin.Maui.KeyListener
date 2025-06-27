namespace Plugin.Maui.KeyListener;

public sealed class KeyPressedEventArgs : EventArgs
{
	public KeyboardModifiers Modifiers { get; internal set; }

	public KeyboardKeys Keys { get; internal set; }

	public string? KeyName { get; internal set; }

	public bool Handled { get; set; }
}