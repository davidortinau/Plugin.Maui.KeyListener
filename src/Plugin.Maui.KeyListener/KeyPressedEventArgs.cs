namespace Plugin.Maui.KeyListener;

/// <summary>
/// Provides data for keyboard key press events in .NET MAUI applications.
/// </summary>
public sealed class KeyPressedEventArgs : EventArgs
{
    /// <summary>
    /// Gets the modifier keys (such as Shift, Control, Alt, Command) that were active when the key event occurred.
    /// </summary>
    public KeyboardModifiers Modifiers { get; internal set; }

    /// <summary>
    /// Gets the logical key that was pressed, represented by the <see cref="KeyboardKeys"/> enumeration.
    /// </summary>
    public KeyboardKeys Keys { get; internal set; }

    /// <summary>
    /// Gets the string name of the key that was pressed (e.g., "A", "LeftArrow", "F1").
    /// Useful for debugging or displaying key information.
    /// </summary>
    public string? KeyName { get; internal set; }

    /// <summary>
    /// Gets or sets a value indicating whether the key event has been handled.
    /// If set to true, further processing of the event will be suppressed.
    /// </summary>
    public bool Handled { get; set; }
}