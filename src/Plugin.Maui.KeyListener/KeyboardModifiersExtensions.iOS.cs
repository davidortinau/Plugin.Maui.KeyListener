﻿#if IOS || MACCATALYST
using UIKit;

namespace Plugin.Maui.KeyListener;

internal static class KeyboardModifiersExtensions
{
    static readonly KeyboardModifiers[] VirtualModifiersValues = Enum.GetValues<KeyboardModifiers>();

    static readonly UIKeyModifierFlags[] UIKeyModifierFlagsValues = Enum.GetValues<UIKeyModifierFlags>();

	/// <remarks>
	/// https://developer.apple.com/documentation/uikit/uikeymodifierflags
	/// </remarks>
	internal static UIKeyModifierFlags ToPlatformModifiers(this KeyboardModifiers virtualModifiers)
    {
        UIKeyModifierFlags platformModifiers = 0;

        foreach (KeyboardModifiers virtualModifier in VirtualModifiersValues)
        {
            if (virtualModifiers.HasFlag(virtualModifier))
            {
                UIKeyModifierFlags platformModifier = ToPlatformModifier(virtualModifier);
                platformModifiers |= platformModifier;
            }
        }

        return platformModifiers;
    }

    internal static KeyboardModifiers ToVirtualModifiers(this UIKeyModifierFlags platformModifiers)
    {
        KeyboardModifiers virtualModifiers = 0;

        foreach (UIKeyModifierFlags platformModifier in UIKeyModifierFlagsValues)
        {
            if (platformModifiers.HasFlag(platformModifier))
            {
                KeyboardModifiers virtualModifier = ToVirtualModifier(platformModifier);
                virtualModifiers |= virtualModifier;
            }
        }

        return virtualModifiers;
    }

    static UIKeyModifierFlags ToPlatformModifier(KeyboardModifiers virtualModifier) => virtualModifier switch
    {
        KeyboardModifiers.Alt => UIKeyModifierFlags.Alternate,
        KeyboardModifiers.Command => UIKeyModifierFlags.Command,
        KeyboardModifiers.Control => UIKeyModifierFlags.Control,
        KeyboardModifiers.Shift => UIKeyModifierFlags.Shift,
        _ => 0
    };

    static KeyboardModifiers ToVirtualModifier(UIKeyModifierFlags platformModifier) => platformModifier switch
    {
        UIKeyModifierFlags.AlphaShift => KeyboardModifiers.Shift,
        UIKeyModifierFlags.Alternate => KeyboardModifiers.Alt,
        UIKeyModifierFlags.Command => KeyboardModifiers.Command,
        UIKeyModifierFlags.Control => KeyboardModifiers.Control,
        UIKeyModifierFlags.Shift => KeyboardModifiers.Shift,
        _ => 0
    };
}
#endif