﻿#if WINDOWS

using Windows.System;

namespace Plugin.Maui.KeyListener;

internal static class KeyboardKeysExtensions
{
	internal static VirtualKey ToPlatformKeys(this KeyboardKeys keyboardKeys)
	{
		List<VirtualKey> platformKeyValues = new();

		foreach (KeyboardKeys keyboardKey in Enum.GetValues(typeof(KeyboardKeys)))
		{
			if (keyboardKeys.HasFlag(keyboardKey))
			{
				VirtualKey platformKey = ToPlatformKey(keyboardKey);

				if (platformKey != 0)
					platformKeyValues.Add(platformKey);
			}
		}

		var platformKeys = ToPlatformKeys(platformKeyValues);

		return platformKeys;
	}

	internal static List<VirtualKey> ToPlatformKeyValues(this KeyboardKeys keyboardKeys)
	{
		List<VirtualKey> platformKeyValues = new();

		foreach (KeyboardKeys keyboardKey in Enum.GetValues(typeof(KeyboardKeys)))
		{
			if (keyboardKeys.HasFlag(keyboardKey))
			{
				VirtualKey platformKey = ToPlatformKey(keyboardKey);

				if (platformKey != 0)
					platformKeyValues.Add(platformKey);
			}
		}

		return platformKeyValues;
	}
	internal static KeyboardKeys ToKeyboardKeys(this VirtualKey platformKeys)
	{
		List<KeyboardKeys> keyboardKeyValues = new();

		foreach (VirtualKey platformKey in Enum.GetValues(typeof(VirtualKey)))
		{
			if (platformKeys.HasFlag(platformKey))
			{
				KeyboardKeys keyboardKey = ToKeyboardKey(platformKey);

				if (keyboardKey != 0)
					keyboardKeyValues.Add(keyboardKey);
			}
		}

		var keyboardKeys = ToKeyboardKeys(keyboardKeyValues);

		return keyboardKeys;
	}

	internal static KeyboardKeys ToKeyboardKeys(this List<VirtualKey> platformKeys)
	{
		List<KeyboardKeys> keyboardKeyValues = new();

		foreach (VirtualKey platformKey in platformKeys)
		{
			if (platformKeys.Contains(platformKey))
			{
				KeyboardKeys keyboardKey = ToKeyboardKey(platformKey);

				if (keyboardKey != 0)
					keyboardKeyValues.Add(keyboardKey);
			}
		}

		var keyboardKeys = ToKeyboardKeys(keyboardKeyValues);

		return keyboardKeys;
	}

	internal static VirtualKey ToPlatformKeys(List<VirtualKey> platformKeyValues)
	{
		VirtualKey platformKeys = 0;

		foreach (VirtualKey platformKey in platformKeyValues)
			platformKeys |= platformKey;

		return platformKeys;
	}

	internal static KeyboardKeys ToKeyboardKeys(List<KeyboardKeys> keyboardKeyValues)
	{
		KeyboardKeys keyboardKeys = 0;

		foreach (KeyboardKeys keyboardKey in keyboardKeyValues)
			keyboardKeys |= keyboardKey;

		return keyboardKeys;
	}

	static VirtualKey ToPlatformKey(KeyboardKeys keyboardKey) => keyboardKey switch 
	{ 
		KeyboardKeys.A => VirtualKey.A, KeyboardKeys.B => VirtualKey.B, 
		KeyboardKeys.C => VirtualKey.C, KeyboardKeys.D => VirtualKey.D, 
		KeyboardKeys.E => VirtualKey.E, KeyboardKeys.F => VirtualKey.F, 
		KeyboardKeys.G => VirtualKey.G, KeyboardKeys.H => VirtualKey.H, 
		KeyboardKeys.I => VirtualKey.I, KeyboardKeys.J => VirtualKey.J, 
		KeyboardKeys.K => VirtualKey.K, KeyboardKeys.L => VirtualKey.L, 
		KeyboardKeys.M => VirtualKey.M, KeyboardKeys.N => VirtualKey.N, 
		KeyboardKeys.O => VirtualKey.O, KeyboardKeys.P => VirtualKey.P, 
		KeyboardKeys.Q => VirtualKey.Q, KeyboardKeys.R => VirtualKey.R, 
		KeyboardKeys.S => VirtualKey.S, KeyboardKeys.T => VirtualKey.T, 
		KeyboardKeys.U => VirtualKey.U, KeyboardKeys.V => VirtualKey.V, 
		KeyboardKeys.W => VirtualKey.W, KeyboardKeys.X => VirtualKey.X, 
		KeyboardKeys.Y => VirtualKey.Y, KeyboardKeys.Z => VirtualKey.Z, 
		KeyboardKeys.Number0 => VirtualKey.Number0, KeyboardKeys.Number1 => VirtualKey.Number1, 
		KeyboardKeys.Number2 => VirtualKey.Number2, KeyboardKeys.Number3 => VirtualKey.Number3, 
		KeyboardKeys.Number4 => VirtualKey.Number4, KeyboardKeys.Number5 => VirtualKey.Number5, 
		KeyboardKeys.Number6 => VirtualKey.Number6, KeyboardKeys.Number7 => VirtualKey.Number7, 
		KeyboardKeys.Number8 => VirtualKey.Number8, KeyboardKeys.Number9 => VirtualKey.Number9, 
		KeyboardKeys.Enter => VirtualKey.Enter, KeyboardKeys.Escape => VirtualKey.Escape, 
		KeyboardKeys.Backspace => VirtualKey.Back, KeyboardKeys.Tab => VirtualKey.Tab, 
		KeyboardKeys.Space => VirtualKey.Space, KeyboardKeys.Minus => VirtualKey.Subtract, 
		KeyboardKeys.Plus => VirtualKey.Add, 
		KeyboardKeys.Slash => VirtualKey.Divide, KeyboardKeys.CapsLock => VirtualKey.CapitalLock,
		KeyboardKeys.F1 => VirtualKey.F1, KeyboardKeys.F2 => VirtualKey.F2, 
		KeyboardKeys.F3 => VirtualKey.F3, KeyboardKeys.F4 => VirtualKey.F4, KeyboardKeys.F5 => VirtualKey.F5, 
		KeyboardKeys.F6 => VirtualKey.F6, KeyboardKeys.F7 => VirtualKey.F7, KeyboardKeys.F8 => VirtualKey.F8, 
		KeyboardKeys.F9 => VirtualKey.F9, KeyboardKeys.F10 => VirtualKey.F10, KeyboardKeys.F11 => VirtualKey.F11, 
		KeyboardKeys.F12 => VirtualKey.F12, KeyboardKeys.PrintScreen => VirtualKey.Print, 
		KeyboardKeys.ScrollLock => VirtualKey.Scroll, KeyboardKeys.Pause => VirtualKey.Pause, 
		KeyboardKeys.Insert => VirtualKey.Insert, KeyboardKeys.Home => VirtualKey.Home, 
		KeyboardKeys.PageUp => VirtualKey.PageUp, KeyboardKeys.Delete => VirtualKey.Delete, 
		KeyboardKeys.End => VirtualKey.End, KeyboardKeys.PageDown => VirtualKey.PageDown, 
		KeyboardKeys.RightArrow => VirtualKey.Right, KeyboardKeys.LeftArrow => VirtualKey.Left, 
		KeyboardKeys.DownArrow => VirtualKey.Down, KeyboardKeys.UpArrow => VirtualKey.Up, 
		_ => 0 
	};

	static KeyboardKeys ToKeyboardKey(VirtualKey platformKey) => platformKey switch
	{
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
		VirtualKey.Enter => KeyboardKeys.Enter,
		VirtualKey.Escape => KeyboardKeys.Escape,
		VirtualKey.Back => KeyboardKeys.Backspace,
		VirtualKey.Tab => KeyboardKeys.Tab,
		VirtualKey.Space => KeyboardKeys.Space,
		VirtualKey.Subtract => KeyboardKeys.Minus,
		VirtualKey.Add => KeyboardKeys.Plus,
		//VirtualKey.back => KeyboardKeys.LeftBracket,
		//VirtualKey.RightBracket => KeyboardKeys.RightBracket,
		//VirtualKey.comm => KeyboardKeys.Backslash,
		//VirtualKey.Semicolon => KeyboardKeys.Semicolon,
		//VirtualKey.Apostrophe => KeyboardKeys.Quote,
		//VirtualKey.Grave => KeyboardKeys.GraveAccent,
		//VirtualKey.Comma => KeyboardKeys.Comma,
		//VirtualKey.Period => KeyboardKeys.Period,
		VirtualKey.Divide => KeyboardKeys.Slash,
		//VirtualKey.CapsLock => KeyboardKeys.CapsLock,
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
		//VirtualKey.PrintScreen => KeyboardKeys.PrintScreen,
		VirtualKey.Scroll => KeyboardKeys.ScrollLock,
		VirtualKey.Pause => KeyboardKeys.Pause,
		VirtualKey.Insert => KeyboardKeys.Insert,
		VirtualKey.Home => KeyboardKeys.Home,
		VirtualKey.PageUp => KeyboardKeys.PageUp,
		VirtualKey.Delete => KeyboardKeys.Delete,
		VirtualKey.End => KeyboardKeys.End,
		VirtualKey.PageDown => KeyboardKeys.PageDown,
		VirtualKey.Right => KeyboardKeys.RightArrow,
		VirtualKey.Left => KeyboardKeys.LeftArrow,
		VirtualKey.Down => KeyboardKeys.DownArrow,
		VirtualKey.Up => KeyboardKeys.UpArrow,
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
		_ => 0
	};
}
#endif