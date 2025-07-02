using Windows.System;
using Microsoft.UI.Xaml.Input;
using System.Diagnostics;

namespace Plugin.Maui.KeyListener;

static partial class KeyboardKeysExtensions
{
    /// <remarks>
    ///     https://learn.microsoft.com/en-us/windows/win32/inputdev/virtual-key-codes
    /// </remarks>
    public static VirtualKey ToVirtualKey(KeyboardKeys keyboardKey)
    {
        VirtualKey vk = keyboardKey switch
        {
            #region Letters
            KeyboardKeys.A => VirtualKey.A,
            KeyboardKeys.B => VirtualKey.B,
            KeyboardKeys.C => VirtualKey.C,
            KeyboardKeys.D => VirtualKey.D,
            KeyboardKeys.E => VirtualKey.E,
            KeyboardKeys.F => VirtualKey.F,
            KeyboardKeys.G => VirtualKey.G,
            KeyboardKeys.H => VirtualKey.H,
            KeyboardKeys.I => VirtualKey.I,
            KeyboardKeys.J => VirtualKey.J,
            KeyboardKeys.K => VirtualKey.K,
            KeyboardKeys.L => VirtualKey.L,
            KeyboardKeys.M => VirtualKey.M,
            KeyboardKeys.N => VirtualKey.N,
            KeyboardKeys.O => VirtualKey.O,
            KeyboardKeys.P => VirtualKey.P,
            KeyboardKeys.Q => VirtualKey.Q,
            KeyboardKeys.R => VirtualKey.R,
            KeyboardKeys.S => VirtualKey.S,
            KeyboardKeys.T => VirtualKey.T,
            KeyboardKeys.U => VirtualKey.U,
            KeyboardKeys.V => VirtualKey.V,
            KeyboardKeys.W => VirtualKey.W,
            KeyboardKeys.X => VirtualKey.X,
            KeyboardKeys.Y => VirtualKey.Y,
            KeyboardKeys.Z => VirtualKey.Z,
            #endregion

            #region Numbers
            KeyboardKeys.Number0 => VirtualKey.Number0,
            KeyboardKeys.Number1 => VirtualKey.Number1,
            KeyboardKeys.Number2 => VirtualKey.Number2,
            KeyboardKeys.Number3 => VirtualKey.Number3,
            KeyboardKeys.Number4 => VirtualKey.Number4,
            KeyboardKeys.Number5 => VirtualKey.Number5,
            KeyboardKeys.Number6 => VirtualKey.Number6,
            KeyboardKeys.Number7 => VirtualKey.Number7,
            KeyboardKeys.Number8 => VirtualKey.Number8,
            KeyboardKeys.Number9 => VirtualKey.Number9,
            #endregion

            #region Function Keys
            KeyboardKeys.Escape => VirtualKey.Escape,
            KeyboardKeys.F1 => VirtualKey.F1,
            KeyboardKeys.F2 => VirtualKey.F2,
            KeyboardKeys.F3 => VirtualKey.F3,
            KeyboardKeys.F4 => VirtualKey.F4,
            KeyboardKeys.F5 => VirtualKey.F5,
            KeyboardKeys.F6 => VirtualKey.F6,
            KeyboardKeys.F7 => VirtualKey.F7,
            KeyboardKeys.F8 => VirtualKey.F8,
            KeyboardKeys.F9 => VirtualKey.F9,
            KeyboardKeys.F10 => VirtualKey.F10,
            KeyboardKeys.F11 => VirtualKey.F11,
            KeyboardKeys.F12 => VirtualKey.F12,
            KeyboardKeys.PrintScreen => VirtualKey.Print,
            KeyboardKeys.ScrollLock => VirtualKey.Scroll,
            KeyboardKeys.Pause => VirtualKey.Pause,
            #endregion

            #region Symbols and Editing
            KeyboardKeys.Backquote or KeyboardKeys.GraveAccent => (VirtualKey)0xC0, // VK_OEM_3
            KeyboardKeys.Minus => VirtualKey.Subtract,
            KeyboardKeys.Equals => VirtualKey.Add,
            KeyboardKeys.Backspace => VirtualKey.Back,
            KeyboardKeys.Tab => VirtualKey.Tab,
            KeyboardKeys.LeftBracket => (VirtualKey)0xDB, // VK_OEM_4
            KeyboardKeys.RightBracket => (VirtualKey)0xDD, // VK_OEM_6
            KeyboardKeys.Backslash => (VirtualKey)0xDC, // VK_OEM_5
            KeyboardKeys.CapsLock => VirtualKey.CapitalLock,
            KeyboardKeys.Semicolon => (VirtualKey)0xBA, // VK_OEM_1
            KeyboardKeys.Quote => (VirtualKey)0xDE, // VK_OEM_7
            KeyboardKeys.Return => VirtualKey.Enter,
            KeyboardKeys.LeftShift => VirtualKey.LeftShift,
            KeyboardKeys.RightShift => VirtualKey.RightShift,
            KeyboardKeys.LeftControl => VirtualKey.LeftControl,
            KeyboardKeys.RightControl => VirtualKey.RightControl,
            KeyboardKeys.LeftAlt => VirtualKey.LeftMenu,
            KeyboardKeys.RightAlt => VirtualKey.RightMenu,
            // Windows: Command keys mapped to Windows keys
            KeyboardKeys.LeftCommand => VirtualKey.LeftWindows,
            KeyboardKeys.RightCommand => VirtualKey.RightWindows,
            KeyboardKeys.Space => VirtualKey.Space,
            KeyboardKeys.Insert => VirtualKey.Insert,
            KeyboardKeys.Delete => VirtualKey.Delete,
            KeyboardKeys.Home => VirtualKey.Home,
            KeyboardKeys.End => VirtualKey.End,
            KeyboardKeys.PageUp => VirtualKey.PageUp,
            KeyboardKeys.PageDown => VirtualKey.PageDown,
            KeyboardKeys.LeftArrow => VirtualKey.Left,
            KeyboardKeys.RightArrow => VirtualKey.Right,
            KeyboardKeys.UpArrow => VirtualKey.Up,
            KeyboardKeys.DownArrow => VirtualKey.Down,
            #endregion

            #region Numpad
            KeyboardKeys.NumLock => VirtualKey.NumberKeyLock,
            KeyboardKeys.NumPadDivide => VirtualKey.Divide,
            KeyboardKeys.NumPadMultiply => VirtualKey.Multiply,
            KeyboardKeys.NumPadMinus => VirtualKey.Subtract,
            KeyboardKeys.NumPadPlus => VirtualKey.Add,
            KeyboardKeys.NumPadEnter => VirtualKey.Enter,
            KeyboardKeys.NumPadPeriod => VirtualKey.Decimal,
            KeyboardKeys.NumPad0 => VirtualKey.NumberPad0,
            KeyboardKeys.NumPad1 => VirtualKey.NumberPad1,
            KeyboardKeys.NumPad2 => VirtualKey.NumberPad2,
            KeyboardKeys.NumPad3 => VirtualKey.NumberPad3,
            KeyboardKeys.NumPad4 => VirtualKey.NumberPad4,
            KeyboardKeys.NumPad5 => VirtualKey.NumberPad5,
            KeyboardKeys.NumPad6 => VirtualKey.NumberPad6,
            KeyboardKeys.NumPad7 => VirtualKey.NumberPad7,
            KeyboardKeys.NumPad8 => VirtualKey.NumberPad8,
            KeyboardKeys.NumPad9 => VirtualKey.NumberPad9,
            KeyboardKeys.Enter => VirtualKey.Enter,
            KeyboardKeys.Plus => VirtualKey.Add,
            KeyboardKeys.Comma => (VirtualKey)0xBC, // VK_OEM_COMMA
            KeyboardKeys.Period => (VirtualKey)0xBE, // VK_OEM_PERIOD
            KeyboardKeys.Slash => VirtualKey.Divide,
            KeyboardKeys.NumPadDecimal => VirtualKey.Delete,
            #endregion

            KeyboardKeys.None => VirtualKey.None,

            _ => VirtualKey.None
        };

        // Log unmapped keys for debug purposes
        if (vk == VirtualKey.None && keyboardKey != KeyboardKeys.None)
        {
            Debug.WriteLine($"[KeyboardKeysExtensions] Unmapped KeyboardKey: {keyboardKey}");
        }

        return vk;
    }

    public static KeyboardKeys ToKeyboardKeys(this VirtualKey platformKey)
    {
        return platformKey switch
        {
            VirtualKey.None => KeyboardKeys.None,
            VirtualKey.A => KeyboardKeys.A,
            VirtualKey.B => KeyboardKeys.B,
            VirtualKey.C => KeyboardKeys.C,
            VirtualKey.D => KeyboardKeys.D,
            VirtualKey.E => KeyboardKeys.E,
            VirtualKey.F => KeyboardKeys.F,
            VirtualKey.G => KeyboardKeys.G,
            VirtualKey.H => KeyboardKeys.H,
            VirtualKey.I => KeyboardKeys.I,
            VirtualKey.J => KeyboardKeys.J,
            VirtualKey.K => KeyboardKeys.K,
            VirtualKey.L => KeyboardKeys.L,
            VirtualKey.M => KeyboardKeys.M,
            VirtualKey.N => KeyboardKeys.N,
            VirtualKey.O => KeyboardKeys.O,
            VirtualKey.P => KeyboardKeys.P,
            VirtualKey.Q => KeyboardKeys.Q,
            VirtualKey.R => KeyboardKeys.R,
            VirtualKey.S => KeyboardKeys.S,
            VirtualKey.T => KeyboardKeys.T,
            VirtualKey.U => KeyboardKeys.U,
            VirtualKey.V => KeyboardKeys.V,
            VirtualKey.W => KeyboardKeys.W,
            VirtualKey.X => KeyboardKeys.X,
            VirtualKey.Y => KeyboardKeys.Y,
            VirtualKey.Z => KeyboardKeys.Z,
            VirtualKey.Number0 => KeyboardKeys.Number0,
            VirtualKey.Number1 => KeyboardKeys.Number1,
            VirtualKey.Number2 => KeyboardKeys.Number2,
            VirtualKey.Number3 => KeyboardKeys.Number3,
            VirtualKey.Number4 => KeyboardKeys.Number4,
            VirtualKey.Number5 => KeyboardKeys.Number5,
            VirtualKey.Number6 => KeyboardKeys.Number6,
            VirtualKey.Number7 => KeyboardKeys.Number7,
            VirtualKey.Number8 => KeyboardKeys.Number8,
            VirtualKey.Number9 => KeyboardKeys.Number9,
            VirtualKey.Escape => KeyboardKeys.Escape,
            VirtualKey.F1 => KeyboardKeys.F1,
            VirtualKey.F2 => KeyboardKeys.F2,
            VirtualKey.F3 => KeyboardKeys.F3,
            VirtualKey.F4 => KeyboardKeys.F4,
            VirtualKey.F5 => KeyboardKeys.F5,
            VirtualKey.F6 => KeyboardKeys.F6,
            VirtualKey.F7 => KeyboardKeys.F7,
            VirtualKey.F8 => KeyboardKeys.F8,
            VirtualKey.F9 => KeyboardKeys.F9,
            VirtualKey.F10 => KeyboardKeys.F10,
            VirtualKey.F11 => KeyboardKeys.F11,
            VirtualKey.F12 => KeyboardKeys.F12,
            VirtualKey.Print => KeyboardKeys.PrintScreen,
            VirtualKey.Scroll => KeyboardKeys.ScrollLock,
            VirtualKey.Pause => KeyboardKeys.Pause,
            (VirtualKey)0xC0 => KeyboardKeys.Backquote, // VK_OEM_3
            VirtualKey.Subtract => KeyboardKeys.Minus,
            VirtualKey.Add => KeyboardKeys.Equals,
            VirtualKey.Back => KeyboardKeys.Backspace,
            VirtualKey.Tab => KeyboardKeys.Tab,
            (VirtualKey)0xDB => KeyboardKeys.LeftBracket, // VK_OEM_4
            (VirtualKey)0xDD => KeyboardKeys.RightBracket, // VK_OEM_6
            (VirtualKey)0xDC => KeyboardKeys.Backslash, // VK_OEM_5
            VirtualKey.CapitalLock => KeyboardKeys.CapsLock,
            (VirtualKey)0xBA => KeyboardKeys.Semicolon, // VK_OEM_1
            (VirtualKey)0xDE => KeyboardKeys.Quote, // VK_OEM_7
            VirtualKey.Enter => KeyboardKeys.Return,
            VirtualKey.LeftShift => KeyboardKeys.LeftShift,
            VirtualKey.RightShift => KeyboardKeys.RightShift,
            VirtualKey.LeftControl => KeyboardKeys.LeftControl,
            VirtualKey.RightControl => KeyboardKeys.RightControl,
            VirtualKey.LeftMenu => KeyboardKeys.LeftAlt,
            VirtualKey.RightMenu => KeyboardKeys.RightAlt,
            VirtualKey.LeftWindows => KeyboardKeys.LeftCommand,
            VirtualKey.RightWindows => KeyboardKeys.RightCommand,
            VirtualKey.Space => KeyboardKeys.Space,
            VirtualKey.Insert => KeyboardKeys.Insert,
            VirtualKey.Delete => KeyboardKeys.Delete,
            VirtualKey.Home => KeyboardKeys.Home,
            VirtualKey.End => KeyboardKeys.End,
            VirtualKey.PageUp => KeyboardKeys.PageUp,
            VirtualKey.PageDown => KeyboardKeys.PageDown,
            VirtualKey.Left => KeyboardKeys.LeftArrow,
            VirtualKey.Right => KeyboardKeys.RightArrow,
            VirtualKey.Up => KeyboardKeys.UpArrow,
            VirtualKey.Down => KeyboardKeys.DownArrow,
            VirtualKey.NumberKeyLock => KeyboardKeys.NumLock,
            VirtualKey.Divide => KeyboardKeys.NumPadDivide,
            VirtualKey.Multiply => KeyboardKeys.NumPadMultiply,
            VirtualKey.NumberPad0 => KeyboardKeys.NumPad0,
            VirtualKey.NumberPad1 => KeyboardKeys.NumPad1,
            VirtualKey.NumberPad2 => KeyboardKeys.NumPad2,
            VirtualKey.NumberPad3 => KeyboardKeys.NumPad3,
            VirtualKey.NumberPad4 => KeyboardKeys.NumPad4,
            VirtualKey.NumberPad5 => KeyboardKeys.NumPad5,
            VirtualKey.NumberPad6 => KeyboardKeys.NumPad6,
            VirtualKey.NumberPad7 => KeyboardKeys.NumPad7,
            VirtualKey.NumberPad8 => KeyboardKeys.NumPad8,
            VirtualKey.NumberPad9 => KeyboardKeys.NumPad9,
            VirtualKey.Decimal => KeyboardKeys.NumPadPeriod,
            (VirtualKey)0xBC => KeyboardKeys.Comma, // VK_OEM_COMMA
            (VirtualKey)0xBE => KeyboardKeys.Period, // VK_OEM_PERIOD
            _ => KeyboardKeys.None
        };
    }

    internal static KeyPressedEventArgs ToKeyPressedEventArgs(this KeyRoutedEventArgs e)
    {
        var virtualKeyModifiers = KeyboardModifiersExtensions.GetVirtualKeyModifiers();
            var vk = (VirtualKey)e.Key; // Use e.Key directly for more accurate mapping
        return new KeyPressedEventArgs
        {
            Modifiers = virtualKeyModifiers.ToKeyboardModifiers(),
            Keys = vk.ToKeyboardKeys(),
            KeyName = vk.ToKeyboardKeys().ToString()
        };
    }
}