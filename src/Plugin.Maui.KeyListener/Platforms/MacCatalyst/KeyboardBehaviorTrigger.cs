namespace Plugin.Maui.KeyListener;

using UIKit;


public partial class KeyboardBehaviorTrigger
{
	internal UIKeyModifierFlags PlatformModifiers { get; private set; }
    internal UIKeyboardHidUsage PlatformKey { get; private set; }

    partial void SetPlatformModifiers(KeyboardModifiers modifiers)
        => PlatformModifiers = modifiers.ToPlatformModifiers();

    partial void SetPlatformKeys(KeyboardKeys key)
		=> PlatformKey = key.ToUIKeyboardHidUsage();
}
