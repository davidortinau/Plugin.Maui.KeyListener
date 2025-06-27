namespace Plugin.Maui.KeyListener;

using UIKit;
using System.Diagnostics;

/// <remarks>
///     https://developer.apple.com/documentation/uikit/uikeyboardhidusage
/// </remarks>
static partial class KeyboardKeysExtensions
{
    /// <summary>
    /// Maps <see cref="KeyboardKeys"/> to <see cref="UIKeyboardHidUsage"/>.
    /// Note: Mac Catalyst does not expose Command key HID usages (UIKeyboardHidUsage.KeyboardLeftGUI/KeyboardRightGUI).
    /// As a workaround, LeftCommand and RightCommand are mapped to LeftAlt and RightAlt respectively.
    /// See: https://developer.apple.com/documentation/uikit/uikeyboardhidusage
    /// </summary>
    public static UIKeyboardHidUsage ToUIKeyboardHidUsage(this KeyboardKeys keyboardKey)
    {
		UIKeyboardHidUsage usage = keyboardKey switch
        {
            #region Letters
            KeyboardKeys.A => UIKeyboardHidUsage.KeyboardA,
            KeyboardKeys.B => UIKeyboardHidUsage.KeyboardB,
            KeyboardKeys.C => UIKeyboardHidUsage.KeyboardC,
            KeyboardKeys.D => UIKeyboardHidUsage.KeyboardD,
            KeyboardKeys.E => UIKeyboardHidUsage.KeyboardE,
            KeyboardKeys.F => UIKeyboardHidUsage.KeyboardF,
            KeyboardKeys.G => UIKeyboardHidUsage.KeyboardG,
            KeyboardKeys.H => UIKeyboardHidUsage.KeyboardH,
            KeyboardKeys.I => UIKeyboardHidUsage.KeyboardI,
            KeyboardKeys.J => UIKeyboardHidUsage.KeyboardJ,
            KeyboardKeys.K => UIKeyboardHidUsage.KeyboardK,
            KeyboardKeys.L => UIKeyboardHidUsage.KeyboardL,
            KeyboardKeys.M => UIKeyboardHidUsage.KeyboardM,
            KeyboardKeys.N => UIKeyboardHidUsage.KeyboardN,
            KeyboardKeys.O => UIKeyboardHidUsage.KeyboardO,
            KeyboardKeys.P => UIKeyboardHidUsage.KeyboardP,
            KeyboardKeys.Q => UIKeyboardHidUsage.KeyboardQ,
            KeyboardKeys.R => UIKeyboardHidUsage.KeyboardR,
            KeyboardKeys.S => UIKeyboardHidUsage.KeyboardS,
            KeyboardKeys.T => UIKeyboardHidUsage.KeyboardT,
            KeyboardKeys.U => UIKeyboardHidUsage.KeyboardU,
            KeyboardKeys.V => UIKeyboardHidUsage.KeyboardV,
            KeyboardKeys.W => UIKeyboardHidUsage.KeyboardW,
            KeyboardKeys.X => UIKeyboardHidUsage.KeyboardX,
            KeyboardKeys.Y => UIKeyboardHidUsage.KeyboardY,
            KeyboardKeys.Z => UIKeyboardHidUsage.KeyboardZ,
            #endregion

            #region Numbers
            KeyboardKeys.Number0 => UIKeyboardHidUsage.Keyboard0,
            KeyboardKeys.Number1 => UIKeyboardHidUsage.Keyboard1,
            KeyboardKeys.Number2 => UIKeyboardHidUsage.Keyboard2,
            KeyboardKeys.Number3 => UIKeyboardHidUsage.Keyboard3,
            KeyboardKeys.Number4 => UIKeyboardHidUsage.Keyboard4,
            KeyboardKeys.Number5 => UIKeyboardHidUsage.Keyboard5,
            KeyboardKeys.Number6 => UIKeyboardHidUsage.Keyboard6,
            KeyboardKeys.Number7 => UIKeyboardHidUsage.Keyboard7,
            KeyboardKeys.Number8 => UIKeyboardHidUsage.Keyboard8,
            KeyboardKeys.Number9 => UIKeyboardHidUsage.Keyboard9,
            #endregion

            #region Function Keys
            KeyboardKeys.Escape => UIKeyboardHidUsage.KeyboardEscape,
            KeyboardKeys.F1 => UIKeyboardHidUsage.KeyboardF1,
            KeyboardKeys.F2 => UIKeyboardHidUsage.KeyboardF2,
            KeyboardKeys.F3 => UIKeyboardHidUsage.KeyboardF3,
            KeyboardKeys.F4 => UIKeyboardHidUsage.KeyboardF4,
            KeyboardKeys.F5 => UIKeyboardHidUsage.KeyboardF5,
            KeyboardKeys.F6 => UIKeyboardHidUsage.KeyboardF6,
            KeyboardKeys.F7 => UIKeyboardHidUsage.KeyboardF7,
            KeyboardKeys.F8 => UIKeyboardHidUsage.KeyboardF8,
            KeyboardKeys.F9 => UIKeyboardHidUsage.KeyboardF9,
            KeyboardKeys.F10 => UIKeyboardHidUsage.KeyboardF10,
            KeyboardKeys.F11 => UIKeyboardHidUsage.KeyboardF11,
            KeyboardKeys.F12 => UIKeyboardHidUsage.KeyboardF12,
            KeyboardKeys.PrintScreen => UIKeyboardHidUsage.KeyboardPrintScreen,
            KeyboardKeys.ScrollLock => UIKeyboardHidUsage.KeyboardScrollLock,
            KeyboardKeys.Pause => UIKeyboardHidUsage.KeyboardPause,
            #endregion

            #region Symbols and Editing
            KeyboardKeys.Backquote => UIKeyboardHidUsage.KeyboardGraveAccentAndTilde,
            KeyboardKeys.Minus => UIKeyboardHidUsage.KeyboardHyphen,
            KeyboardKeys.Equals => UIKeyboardHidUsage.KeyboardEqualSign,
            KeyboardKeys.Backspace => UIKeyboardHidUsage.KeyboardDeleteOrBackspace,
            KeyboardKeys.Tab => UIKeyboardHidUsage.KeyboardTab,
            KeyboardKeys.LeftBracket => UIKeyboardHidUsage.KeyboardOpenBracket,
            KeyboardKeys.RightBracket => UIKeyboardHidUsage.KeyboardCloseBracket,
            KeyboardKeys.Backslash => UIKeyboardHidUsage.KeyboardBackslash,
            KeyboardKeys.CapsLock => UIKeyboardHidUsage.KeyboardCapsLock,
            KeyboardKeys.Semicolon => UIKeyboardHidUsage.KeyboardSemicolon,
            KeyboardKeys.Quote => UIKeyboardHidUsage.KeyboardQuote,
            KeyboardKeys.Return => UIKeyboardHidUsage.KeyboardReturnOrEnter,
            KeyboardKeys.LeftShift => UIKeyboardHidUsage.KeyboardLeftShift,
            KeyboardKeys.RightShift => UIKeyboardHidUsage.KeyboardRightShift,
            KeyboardKeys.LeftControl => UIKeyboardHidUsage.KeyboardLeftControl,
            KeyboardKeys.RightControl => UIKeyboardHidUsage.KeyboardRightControl,
            KeyboardKeys.LeftAlt => UIKeyboardHidUsage.KeyboardLeftAlt,
            KeyboardKeys.RightAlt => UIKeyboardHidUsage.KeyboardRightAlt,
            // Mac Catalyst does not expose Command key HID usages; mapped to Alt as workaround.
            KeyboardKeys.LeftCommand => UIKeyboardHidUsage.KeyboardLeftAlt,
            KeyboardKeys.RightCommand => UIKeyboardHidUsage.KeyboardRightAlt,
            KeyboardKeys.Space => UIKeyboardHidUsage.KeyboardSpacebar,
            KeyboardKeys.Insert => UIKeyboardHidUsage.KeyboardInsert,
            KeyboardKeys.Delete => UIKeyboardHidUsage.KeyboardDeleteForward,
            KeyboardKeys.Home => UIKeyboardHidUsage.KeyboardHome,
            KeyboardKeys.End => UIKeyboardHidUsage.KeyboardEnd,
            KeyboardKeys.PageUp => UIKeyboardHidUsage.KeyboardPageUp,
            KeyboardKeys.PageDown => UIKeyboardHidUsage.KeyboardPageDown,
            KeyboardKeys.LeftArrow => UIKeyboardHidUsage.KeyboardLeftArrow,
            KeyboardKeys.RightArrow => UIKeyboardHidUsage.KeyboardRightArrow,
            KeyboardKeys.UpArrow => UIKeyboardHidUsage.KeyboardUpArrow,
            KeyboardKeys.DownArrow => UIKeyboardHidUsage.KeyboardDownArrow,
            #endregion

            #region Numpad
            KeyboardKeys.NumLock => UIKeyboardHidUsage.KeypadNumLock,
            KeyboardKeys.NumPadDivide => UIKeyboardHidUsage.KeypadSlash,
            KeyboardKeys.NumPadMultiply => UIKeyboardHidUsage.KeypadAsterisk,
            KeyboardKeys.NumPadMinus => UIKeyboardHidUsage.KeypadHyphen,
            KeyboardKeys.NumPadPlus => UIKeyboardHidUsage.KeypadPlus,
            KeyboardKeys.NumPadEnter => UIKeyboardHidUsage.KeypadEnter,
            KeyboardKeys.NumPadPeriod => UIKeyboardHidUsage.KeypadPeriod,
            KeyboardKeys.NumPad0 => UIKeyboardHidUsage.Keypad0,
            KeyboardKeys.NumPad1 => UIKeyboardHidUsage.Keypad1,
            KeyboardKeys.NumPad2 => UIKeyboardHidUsage.Keypad2,
            KeyboardKeys.NumPad3 => UIKeyboardHidUsage.Keypad3,
            KeyboardKeys.NumPad4 => UIKeyboardHidUsage.Keypad4,
            KeyboardKeys.NumPad5 => UIKeyboardHidUsage.Keypad5,
            KeyboardKeys.NumPad6 => UIKeyboardHidUsage.Keypad6,
            KeyboardKeys.NumPad7 => UIKeyboardHidUsage.Keypad7,
            KeyboardKeys.NumPad8 => UIKeyboardHidUsage.Keypad8,
            KeyboardKeys.NumPad9 => UIKeyboardHidUsage.Keypad9,
            KeyboardKeys.Enter => UIKeyboardHidUsage.KeyboardReturnOrEnter,
            KeyboardKeys.Plus => UIKeyboardHidUsage.KeyboardEqualSign,
            KeyboardKeys.GraveAccent => UIKeyboardHidUsage.KeyboardGraveAccentAndTilde,
            KeyboardKeys.Comma => UIKeyboardHidUsage.KeyboardComma,
            KeyboardKeys.Period => UIKeyboardHidUsage.KeyboardPeriod,
            KeyboardKeys.Slash => UIKeyboardHidUsage.KeyboardSlash,
            KeyboardKeys.NumPadDecimal => UIKeyboardHidUsage.KeypadPeriod,
            #endregion

            KeyboardKeys.None => 0,

            _ => 0
        };

        // Log unmapped keys for debug purposes
        if (usage == 0 && keyboardKey != KeyboardKeys.None)
        {
            Debug.WriteLine($"[KeyboardKeysExtensions] Unmapped KeyboardKey: {keyboardKey}");
        }

        return usage;
    }

    public static KeyboardKeys ToKeyboardKeys(this UIKeyboardHidUsage platformKey)
    {
        return platformKey switch
        {
            UIKeyboardHidUsage.KeyboardA => KeyboardKeys.A,
            UIKeyboardHidUsage.KeyboardB => KeyboardKeys.B,
            UIKeyboardHidUsage.KeyboardC => KeyboardKeys.C,
            UIKeyboardHidUsage.KeyboardD => KeyboardKeys.D,
            UIKeyboardHidUsage.KeyboardE => KeyboardKeys.E,
            UIKeyboardHidUsage.KeyboardF => KeyboardKeys.F,
            UIKeyboardHidUsage.KeyboardG => KeyboardKeys.G,
            UIKeyboardHidUsage.KeyboardH => KeyboardKeys.H,
            UIKeyboardHidUsage.KeyboardI => KeyboardKeys.I,
            UIKeyboardHidUsage.KeyboardJ => KeyboardKeys.J,
            UIKeyboardHidUsage.KeyboardK => KeyboardKeys.K,
            UIKeyboardHidUsage.KeyboardL => KeyboardKeys.L,
            UIKeyboardHidUsage.KeyboardM => KeyboardKeys.M,
            UIKeyboardHidUsage.KeyboardN => KeyboardKeys.N,
            UIKeyboardHidUsage.KeyboardO => KeyboardKeys.O,
            UIKeyboardHidUsage.KeyboardP => KeyboardKeys.P,
            UIKeyboardHidUsage.KeyboardQ => KeyboardKeys.Q,
            UIKeyboardHidUsage.KeyboardR => KeyboardKeys.R,
            UIKeyboardHidUsage.KeyboardS => KeyboardKeys.S,
            UIKeyboardHidUsage.KeyboardT => KeyboardKeys.T,
            UIKeyboardHidUsage.KeyboardU => KeyboardKeys.U,
            UIKeyboardHidUsage.KeyboardV => KeyboardKeys.V,
            UIKeyboardHidUsage.KeyboardW => KeyboardKeys.W,
            UIKeyboardHidUsage.KeyboardX => KeyboardKeys.X,
            UIKeyboardHidUsage.KeyboardY => KeyboardKeys.Y,
            UIKeyboardHidUsage.KeyboardZ => KeyboardKeys.Z,
            UIKeyboardHidUsage.Keyboard0 => KeyboardKeys.Number0,
            UIKeyboardHidUsage.Keyboard1 => KeyboardKeys.Number1,
            UIKeyboardHidUsage.Keyboard2 => KeyboardKeys.Number2,
            UIKeyboardHidUsage.Keyboard3 => KeyboardKeys.Number3,
            UIKeyboardHidUsage.Keyboard4 => KeyboardKeys.Number4,
            UIKeyboardHidUsage.Keyboard5 => KeyboardKeys.Number5,
            UIKeyboardHidUsage.Keyboard6 => KeyboardKeys.Number6,
            UIKeyboardHidUsage.Keyboard7 => KeyboardKeys.Number7,
            UIKeyboardHidUsage.Keyboard8 => KeyboardKeys.Number8,
            UIKeyboardHidUsage.Keyboard9 => KeyboardKeys.Number9,
            UIKeyboardHidUsage.KeyboardEscape => KeyboardKeys.Escape,
            UIKeyboardHidUsage.KeyboardF1 => KeyboardKeys.F1,
            UIKeyboardHidUsage.KeyboardF2 => KeyboardKeys.F2,
            UIKeyboardHidUsage.KeyboardF3 => KeyboardKeys.F3,
            UIKeyboardHidUsage.KeyboardF4 => KeyboardKeys.F4,
            UIKeyboardHidUsage.KeyboardF5 => KeyboardKeys.F5,
            UIKeyboardHidUsage.KeyboardF6 => KeyboardKeys.F6,
            UIKeyboardHidUsage.KeyboardF7 => KeyboardKeys.F7,
            UIKeyboardHidUsage.KeyboardF8 => KeyboardKeys.F8,
            UIKeyboardHidUsage.KeyboardF9 => KeyboardKeys.F9,
            UIKeyboardHidUsage.KeyboardF10 => KeyboardKeys.F10,
            UIKeyboardHidUsage.KeyboardF11 => KeyboardKeys.F11,
            UIKeyboardHidUsage.KeyboardF12 => KeyboardKeys.F12,
            UIKeyboardHidUsage.KeyboardPrintScreen => KeyboardKeys.PrintScreen,
            UIKeyboardHidUsage.KeyboardScrollLock => KeyboardKeys.ScrollLock,
            UIKeyboardHidUsage.KeyboardPause => KeyboardKeys.Pause,
            UIKeyboardHidUsage.KeyboardGraveAccentAndTilde => KeyboardKeys.Backquote,
            UIKeyboardHidUsage.KeyboardHyphen => KeyboardKeys.Minus,
            UIKeyboardHidUsage.KeyboardEqualSign => KeyboardKeys.Equals,
            UIKeyboardHidUsage.KeyboardDeleteOrBackspace => KeyboardKeys.Backspace,
            UIKeyboardHidUsage.KeyboardTab => KeyboardKeys.Tab,
            UIKeyboardHidUsage.KeyboardOpenBracket => KeyboardKeys.LeftBracket,
            UIKeyboardHidUsage.KeyboardCloseBracket => KeyboardKeys.RightBracket,
            UIKeyboardHidUsage.KeyboardBackslash => KeyboardKeys.Backslash,
            UIKeyboardHidUsage.KeyboardCapsLock => KeyboardKeys.CapsLock,
            UIKeyboardHidUsage.KeyboardSemicolon => KeyboardKeys.Semicolon,
            UIKeyboardHidUsage.KeyboardQuote => KeyboardKeys.Quote,
            UIKeyboardHidUsage.KeyboardReturnOrEnter => KeyboardKeys.Return,
            UIKeyboardHidUsage.KeyboardLeftShift => KeyboardKeys.LeftShift,
            UIKeyboardHidUsage.KeyboardRightShift => KeyboardKeys.RightShift,
            UIKeyboardHidUsage.KeyboardLeftControl => KeyboardKeys.LeftControl,
            UIKeyboardHidUsage.KeyboardRightControl => KeyboardKeys.RightControl,
            UIKeyboardHidUsage.KeyboardLeftAlt => KeyboardKeys.LeftAlt,
            UIKeyboardHidUsage.KeyboardRightAlt => KeyboardKeys.RightAlt,
            // No Command key HID usages available in Mac Catalyst; cannot map back.
            UIKeyboardHidUsage.KeyboardSpacebar => KeyboardKeys.Space,
            UIKeyboardHidUsage.KeyboardInsert => KeyboardKeys.Insert,
            UIKeyboardHidUsage.KeyboardDeleteForward => KeyboardKeys.Delete,
            UIKeyboardHidUsage.KeyboardHome => KeyboardKeys.Home,
            UIKeyboardHidUsage.KeyboardEnd => KeyboardKeys.End,
            UIKeyboardHidUsage.KeyboardPageUp => KeyboardKeys.PageUp,
            UIKeyboardHidUsage.KeyboardPageDown => KeyboardKeys.PageDown,
            UIKeyboardHidUsage.KeyboardLeftArrow => KeyboardKeys.LeftArrow,
            UIKeyboardHidUsage.KeyboardRightArrow => KeyboardKeys.RightArrow,
            UIKeyboardHidUsage.KeyboardUpArrow => KeyboardKeys.UpArrow,
            UIKeyboardHidUsage.KeyboardDownArrow => KeyboardKeys.DownArrow,
            UIKeyboardHidUsage.KeypadNumLock => KeyboardKeys.NumLock,
            UIKeyboardHidUsage.KeypadSlash => KeyboardKeys.NumPadDivide,
            UIKeyboardHidUsage.KeypadAsterisk => KeyboardKeys.NumPadMultiply,
            UIKeyboardHidUsage.KeypadHyphen => KeyboardKeys.NumPadMinus,
            UIKeyboardHidUsage.KeypadPlus => KeyboardKeys.NumPadPlus,
            UIKeyboardHidUsage.KeypadEnter => KeyboardKeys.NumPadEnter,
            UIKeyboardHidUsage.KeypadPeriod => KeyboardKeys.NumPadPeriod,
            UIKeyboardHidUsage.Keypad0 => KeyboardKeys.NumPad0,
            UIKeyboardHidUsage.Keypad1 => KeyboardKeys.NumPad1,
            UIKeyboardHidUsage.Keypad2 => KeyboardKeys.NumPad2,
            UIKeyboardHidUsage.Keypad3 => KeyboardKeys.NumPad3,
            UIKeyboardHidUsage.Keypad4 => KeyboardKeys.NumPad4,
            UIKeyboardHidUsage.Keypad5 => KeyboardKeys.NumPad5,
            UIKeyboardHidUsage.Keypad6 => KeyboardKeys.NumPad6,
            UIKeyboardHidUsage.Keypad7 => KeyboardKeys.NumPad7,
            UIKeyboardHidUsage.Keypad8 => KeyboardKeys.NumPad8,
            UIKeyboardHidUsage.Keypad9 => KeyboardKeys.NumPad9,
            UIKeyboardHidUsage.KeyboardComma => KeyboardKeys.Comma,
            UIKeyboardHidUsage.KeyboardPeriod => KeyboardKeys.Period,
            UIKeyboardHidUsage.KeyboardSlash => KeyboardKeys.Slash,
            _ => KeyboardKeys.None
        };
    }
}