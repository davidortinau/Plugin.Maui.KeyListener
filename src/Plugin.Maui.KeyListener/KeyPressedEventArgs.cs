namespace Plugin.Maui.KeyListener;

public sealed class KeyPressedEventArgs : EventArgs
{
    public KeyboardModifiers Modifiers { get; internal set; }
    public KeyboardKeys Key { get; internal set; }

    public char KeyChar { get; internal set; }
	public bool Handled { get; set; }
}