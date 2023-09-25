#if IOS || MACCATALYST
using UIKit;

namespace Plugin.Maui.KeyListener;

internal static class KeyboardKeysExtensions
{
    internal static UIKeyboardHidUsage ToPlatformKeys(this KeyboardKeys virtualKeys)
    {
        List<UIKeyboardHidUsage> platformKeyValues = new();

        foreach (KeyboardKeys virtualKey in Enum.GetValues(typeof(KeyboardKeys)))
        {
            if (virtualKeys.HasFlag(virtualKey))
            {
                UIKeyboardHidUsage platformKey = ToPlatformKey(virtualKey);

                if (platformKey != 0)
                    platformKeyValues.Add(platformKey);
            }
        }

        var platformKeys = ToPlatformKeys(platformKeyValues);

        return platformKeys;
    }

    internal static List<UIKeyboardHidUsage> ToPlatformKeyValues(this KeyboardKeys virtualKeys)
    {
        List<UIKeyboardHidUsage> platformKeyValues = new();

        foreach (KeyboardKeys virtualKey in Enum.GetValues(typeof(KeyboardKeys)))
        {
            if (virtualKeys.HasFlag(virtualKey))
            {
                UIKeyboardHidUsage platformKey = ToPlatformKey(virtualKey);

                if (platformKey != 0)
                    platformKeyValues.Add(platformKey);
            }
        }

        return platformKeyValues;
    }

    internal static KeyboardKeys ToVirtualKeys(this UIKeyboardHidUsage platformKeys)
    {
        List<KeyboardKeys> virtualKeyValues = new();

        foreach (UIKeyboardHidUsage platformKey in Enum.GetValues(typeof(UIKeyboardHidUsage)))
        {
            if (platformKeys.HasFlag(platformKey))
            {
                KeyboardKeys virtualKey = ToVirtualKey(platformKey);

                if (virtualKey != 0)
                    virtualKeyValues.Add(virtualKey);
            }
        }

        var virtualKeys = ToVirtualKeys(virtualKeyValues);

        return virtualKeys;
    }

    internal static KeyboardKeys ToVirtualKeys(this List<UIKeyboardHidUsage> platformKeys)
    {
        List<KeyboardKeys> virtualKeyValues = new();

        foreach (UIKeyboardHidUsage platformKey in platformKeys)
        {
            if (platformKeys.Contains(platformKey))
            {
                KeyboardKeys virtualKey = ToVirtualKey(platformKey);

                if (virtualKey != 0)
                    virtualKeyValues.Add(virtualKey);
            }
        }

        var virtualKeys = ToVirtualKeys(virtualKeyValues);

        return virtualKeys;
    }

    internal static UIKeyboardHidUsage ToPlatformKeys(List<UIKeyboardHidUsage> platformKeyValues)
    {
        UIKeyboardHidUsage platformKeys = 0;

        foreach (UIKeyboardHidUsage platformKey in platformKeyValues)
            platformKeys |= platformKey;

        return platformKeys;
    }

    internal static KeyboardKeys ToVirtualKeys(List<KeyboardKeys> virtualKeyValues)
    {
        KeyboardKeys virtualKeys = 0;

        foreach (KeyboardKeys virtualKey in virtualKeyValues)
            virtualKeys |= virtualKey;

        return virtualKeys;
    }

    static UIKeyboardHidUsage ToPlatformKey(KeyboardKeys virtualKey) => virtualKey switch
    {
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
        KeyboardKeys.Enter => UIKeyboardHidUsage.KeyboardReturnOrEnter,
        KeyboardKeys.Escape => UIKeyboardHidUsage.KeyboardEscape,
        KeyboardKeys.Backspace => UIKeyboardHidUsage.KeyboardDeleteOrBackspace,
        KeyboardKeys.Tab => UIKeyboardHidUsage.KeyboardTab,
        KeyboardKeys.Space => UIKeyboardHidUsage.KeyboardSpacebar,
        KeyboardKeys.Minus => UIKeyboardHidUsage.KeyboardHyphen,
        KeyboardKeys.Plus => UIKeyboardHidUsage.KeyboardEqualSign,
        KeyboardKeys.LeftBracket => UIKeyboardHidUsage.KeyboardOpenBracket,
        KeyboardKeys.RightBracket => UIKeyboardHidUsage.KeyboardCloseBracket,
        KeyboardKeys.Backslash => UIKeyboardHidUsage.KeyboardBackslash,
        KeyboardKeys.Semicolon => UIKeyboardHidUsage.KeyboardSemicolon,
        KeyboardKeys.Quote => UIKeyboardHidUsage.KeyboardQuote,
        KeyboardKeys.GraveAccent => UIKeyboardHidUsage.KeyboardGraveAccentAndTilde,
        KeyboardKeys.Comma => UIKeyboardHidUsage.KeyboardComma,
        KeyboardKeys.Period => UIKeyboardHidUsage.KeyboardPeriod,
        KeyboardKeys.Slash => UIKeyboardHidUsage.KeyboardSlash,
        KeyboardKeys.CapsLock => UIKeyboardHidUsage.KeyboardCapsLock,
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
        KeyboardKeys.Insert => UIKeyboardHidUsage.KeyboardInsert,
        KeyboardKeys.Home => UIKeyboardHidUsage.KeyboardHome,
        KeyboardKeys.PageUp => UIKeyboardHidUsage.KeyboardPageUp,
        KeyboardKeys.Delete => UIKeyboardHidUsage.KeyboardDeleteForward,
        KeyboardKeys.End => UIKeyboardHidUsage.KeyboardEnd,
        KeyboardKeys.PageDown => UIKeyboardHidUsage.KeyboardPageDown,
        KeyboardKeys.RightArrow => UIKeyboardHidUsage.KeyboardRightArrow,
        KeyboardKeys.LeftArrow => UIKeyboardHidUsage.KeyboardLeftArrow,
        KeyboardKeys.DownArrow => UIKeyboardHidUsage.KeyboardDownArrow,
        KeyboardKeys.UpArrow => UIKeyboardHidUsage.KeyboardUpArrow,
        _ => 0
    };

    static KeyboardKeys ToVirtualKey(UIKeyboardHidUsage platformKey) => platformKey switch
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
        UIKeyboardHidUsage.KeyboardReturnOrEnter => KeyboardKeys.Enter,
        UIKeyboardHidUsage.KeyboardEscape => KeyboardKeys.Escape,
        UIKeyboardHidUsage.KeyboardDeleteOrBackspace => KeyboardKeys.Backspace,
        UIKeyboardHidUsage.KeyboardTab => KeyboardKeys.Tab,
        UIKeyboardHidUsage.KeyboardSpacebar => KeyboardKeys.Space,
        UIKeyboardHidUsage.KeyboardHyphen => KeyboardKeys.Minus,
        UIKeyboardHidUsage.KeyboardEqualSign => KeyboardKeys.Plus,
        UIKeyboardHidUsage.KeyboardOpenBracket => KeyboardKeys.LeftBracket,
        UIKeyboardHidUsage.KeyboardCloseBracket => KeyboardKeys.RightBracket,
        UIKeyboardHidUsage.KeyboardBackslash => KeyboardKeys.Backslash,
        UIKeyboardHidUsage.KeyboardSemicolon => KeyboardKeys.Semicolon,
        UIKeyboardHidUsage.KeyboardQuote => KeyboardKeys.Quote,
        UIKeyboardHidUsage.KeyboardGraveAccentAndTilde => KeyboardKeys.GraveAccent,
        UIKeyboardHidUsage.KeyboardComma => KeyboardKeys.Comma,
        UIKeyboardHidUsage.KeyboardPeriod => KeyboardKeys.Period,
        UIKeyboardHidUsage.KeyboardSlash => KeyboardKeys.Slash,
        UIKeyboardHidUsage.KeyboardCapsLock => KeyboardKeys.CapsLock,
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
        UIKeyboardHidUsage.KeyboardInsert => KeyboardKeys.Insert,
        UIKeyboardHidUsage.KeyboardHome => KeyboardKeys.Home,
        UIKeyboardHidUsage.KeyboardPageUp => KeyboardKeys.PageUp,
        UIKeyboardHidUsage.KeyboardDeleteForward => KeyboardKeys.Delete,
        UIKeyboardHidUsage.KeyboardEnd => KeyboardKeys.End,
        UIKeyboardHidUsage.KeyboardPageDown => KeyboardKeys.PageDown,
        UIKeyboardHidUsage.KeyboardRightArrow => KeyboardKeys.RightArrow,
        UIKeyboardHidUsage.KeyboardLeftArrow => KeyboardKeys.LeftArrow,
        UIKeyboardHidUsage.KeyboardDownArrow => KeyboardKeys.DownArrow,
        UIKeyboardHidUsage.KeyboardUpArrow => KeyboardKeys.UpArrow,
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
        UIKeyboardHidUsage.KeypadEnter => KeyboardKeys.NumPadEnter,
        UIKeyboardHidUsage.KeypadPlus => KeyboardKeys.NumPadPlus,
        UIKeyboardHidUsage.KeypadAsterisk => KeyboardKeys.NumPadMultiply,
        UIKeyboardHidUsage.KeypadSlash => KeyboardKeys.NumPadDivide,
        UIKeyboardHidUsage.KeypadPeriod => KeyboardKeys.NumPadDecimal,
        _ => 0
    };
}
#endif