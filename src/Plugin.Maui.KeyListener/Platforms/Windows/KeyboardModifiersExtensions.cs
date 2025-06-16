using Windows.System;
using Windows.UI.Core;
using Microsoft.UI.Input;

namespace Plugin.Maui.KeyListener;

static class KeyboardModifiersExtensions
{
	static readonly VirtualKeyModifiers[] VirtualKeyModifierValues =
	[
		VirtualKeyModifiers.Control,
		VirtualKeyModifiers.Menu,
		VirtualKeyModifiers.Shift,
		VirtualKeyModifiers.Windows
	];

	static bool IsKeyDown(VirtualKey key)
	{
		return InputKeyboardSource.GetKeyStateForCurrentThread(key).HasFlag(CoreVirtualKeyStates.Down);
	}

	internal static VirtualKeyModifiers GetVirtualKeyModifiers()
	{
		var modifiers = VirtualKeyModifiers.None;
		if (IsKeyDown(VirtualKey.Control))
		{
			modifiers |= VirtualKeyModifiers.Control;
		}

		if (IsKeyDown(VirtualKey.Menu))
		{
			modifiers |= VirtualKeyModifiers.Menu;
		}

		if (IsKeyDown(VirtualKey.Shift))
		{
			modifiers |= VirtualKeyModifiers.Shift;
		}

		if (IsKeyDown(VirtualKey.LeftWindows) || IsKeyDown(VirtualKey.RightWindows))
		{
			modifiers |= VirtualKeyModifiers.Windows;
		}

		return modifiers;
	}

	public static KeyboardModifiers ToKeyboardModifiers(this VirtualKeyModifiers virtualKeyModifiers)
	{
		var keyboardModifiers = KeyboardModifiers.None;
		foreach (var modifier in VirtualKeyModifierValues)
		{
			if (virtualKeyModifiers.HasFlag(modifier))
			{
				keyboardModifiers |= modifier.ToKeyboardModifier();
			}
		}

		return keyboardModifiers;
	}

	static KeyboardModifiers ToKeyboardModifier(this VirtualKeyModifiers modifier)
	{
		return modifier switch
		{
			VirtualKeyModifiers.Control => KeyboardModifiers.Control,
			VirtualKeyModifiers.Menu => KeyboardModifiers.Alt,
			VirtualKeyModifiers.Shift => KeyboardModifiers.Shift,
			VirtualKeyModifiers.Windows => KeyboardModifiers.Command,
			_ => KeyboardModifiers.None
		};
	}
}