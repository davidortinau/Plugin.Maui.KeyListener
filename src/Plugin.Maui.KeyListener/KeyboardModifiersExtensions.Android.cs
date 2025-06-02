using Android.Views;

namespace Plugin.Maui.KeyListener;

internal static class KeyboardModifiersExtensions
{
    /// <summary>
    /// Converts KeyboardModifiers to Android.Views.MetaKeyStates.
    /// </summary>
    public static MetaKeyStates ToMetaKeyStates(this KeyboardModifiers modifiers)
    {
        MetaKeyStates result = MetaKeyStates.None;

        if (modifiers.HasFlag(KeyboardModifiers.Shift))
            result |= MetaKeyStates.ShiftOn;
        if (modifiers.HasFlag(KeyboardModifiers.Control))
            result |= MetaKeyStates.CtrlOn;
        if (modifiers.HasFlag(KeyboardModifiers.Alt))
            result |= MetaKeyStates.AltOn;
        if (modifiers.HasFlag(KeyboardModifiers.Command))
            result |= MetaKeyStates.MetaOn;

        return result;
    }

    /// <summary>
    /// Converts Android.Views.MetaKeyStates to KeyboardModifiers.
    /// </summary>
    public static KeyboardModifiers ToKeyboardModifiers(this MetaKeyStates metaState)
    {
        KeyboardModifiers result = KeyboardModifiers.None;

        if (metaState.HasFlag(MetaKeyStates.ShiftOn))
            result |= KeyboardModifiers.Shift;
        if (metaState.HasFlag(MetaKeyStates.CtrlOn))
            result |= KeyboardModifiers.Control;
        if (metaState.HasFlag(MetaKeyStates.AltOn))
            result |= KeyboardModifiers.Alt;
        if (metaState.HasFlag(MetaKeyStates.MetaOn))
            result |= KeyboardModifiers.Command;

        return result;
    }
}
