namespace Plugin.Maui.KeyListener;
internal static partial class KeyboardKeysExtensions
{
	internal static char? ToChar(this KeyboardKeys key, KeyboardModifiers modifiers = KeyboardModifiers.None) => WithModifier(key switch
	{
		KeyboardKeys.A => 'a',
		KeyboardKeys.B => 'b',
		KeyboardKeys.Backquote => '`',
		KeyboardKeys.Backslash => '\\',
		KeyboardKeys.Backspace => (char)8,
		KeyboardKeys.C => 'c',
		KeyboardKeys.Comma => ',',
		// CapsLock
		KeyboardKeys.D => 'd',
		KeyboardKeys.Delete => (char)127,
		// DownArrow
		KeyboardKeys.E => 'e',
		// End
		KeyboardKeys.Enter => (char)10, // Carriage Return
		KeyboardKeys.Equals => '=',
		KeyboardKeys.Escape => (char)27,
		KeyboardKeys.F => 'f',
		// F1 - F12
		KeyboardKeys.G => 'g',
		KeyboardKeys.GraveAccent => (char)96,
		KeyboardKeys.H => 'h',
		// Home
		KeyboardKeys.I => 'i',
		// Insert
		KeyboardKeys.J => 'j',
		KeyboardKeys.K => 'k',
		KeyboardKeys.L => 'l',
		// LeftAlt
		// LeftArrow
		KeyboardKeys.LeftBracket => '[',
		// LeftCommand
		// LeftControl
		// LeftShift
		KeyboardKeys.M => 'm',
		KeyboardKeys.Minus => '-',
		KeyboardKeys.N => 'N',
		// None
		KeyboardKeys.Number0 => '0',
		KeyboardKeys.Number1 => '1',
		KeyboardKeys.Number2 => '2',
		KeyboardKeys.Number3 => '3',
		KeyboardKeys.Number4 => '4',
		KeyboardKeys.Number5 => '5',
		KeyboardKeys.Number6 => '6',
		KeyboardKeys.Number7 => '7',
		KeyboardKeys.Number8 => '8',
		KeyboardKeys.Number9 => '9',
		// NumLock
		KeyboardKeys.NumPad0 => '0',
		KeyboardKeys.NumPad1 => '1',
		KeyboardKeys.NumPad2 => '2',
		KeyboardKeys.NumPad3 => '3',
		KeyboardKeys.NumPad4 => '4',
		KeyboardKeys.NumPad5 => '5',
		KeyboardKeys.NumPad6 => '6',
		KeyboardKeys.NumPad7 => '7',
		KeyboardKeys.NumPad8 => '8',
		KeyboardKeys.NumPad9 => '9',
		KeyboardKeys.NumPadDecimal => '.',
		KeyboardKeys.NumPadDivide => '/',
		KeyboardKeys.NumPadEnter => (char)10,
		KeyboardKeys.NumPadMinus => '-',
		KeyboardKeys.NumPadMultiply => '*',
		KeyboardKeys.NumPadPeriod => '.',
		KeyboardKeys.NumPadPlus => '+',
		KeyboardKeys.O => 'o',
		KeyboardKeys.P => 'p',
		// PageUp
		// PageDown
		// Pause
		KeyboardKeys.Period => '.',
		KeyboardKeys.Plus => '+',
		// PrintScreen
		KeyboardKeys.Q => 'q',
		KeyboardKeys.Quote => '"',
		KeyboardKeys.R => 'r',
		KeyboardKeys.Return => (char)10,
		// RightAlt
		// RightArrow
		KeyboardKeys.RightBracket => ']',
		// RightCommand
		// RightCtrl
		// RightShift
		KeyboardKeys.S => 's',
		// ScrollLock
		KeyboardKeys.Semicolon => ';',
		KeyboardKeys.Slash => '/',
		KeyboardKeys.Space => ' ',
		KeyboardKeys.T => 't',
		KeyboardKeys.Tab => '\t',
		KeyboardKeys.U => 'u',
		// UpArrow
		KeyboardKeys.V => 'v',
		KeyboardKeys.W => 'w',
		KeyboardKeys.X => 'x',
		KeyboardKeys.Y => 'y',
		KeyboardKeys.Z => 'z',
		_ => (char?)null
	}, modifiers);

	internal static char? WithModifier(this char? input, KeyboardModifiers modifiers = KeyboardModifiers.None)
	{
		if (!input.HasValue) { return null; }

		return modifiers.HasFlag(KeyboardModifiers.Shift)
			 ? char.ToUpper(input.Value)
			 : input;
	}
}
