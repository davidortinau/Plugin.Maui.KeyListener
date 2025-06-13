#if MACCATALYST
using UIKit;

namespace Plugin.Maui.KeyListener;

public sealed partial class KeyboardBehaviorTrigger
{
	internal UIKeyModifierFlags PlatformModifiers { get; private set; }
    internal UIKeyboardHidUsage PlatformKey { get; private set; }

    void SetPlatformModifiers(KeyboardModifiers modifiers)
        => PlatformModifiers = modifiers.ToPlatformModifiers();

	void SetPlatformKeys(KeyboardKeys key)
		=> PlatformKey = key.ToUIKeyboardHidUsage();
}

internal class KeyboardBehaviorTriggerComparer : IEqualityComparer<KeyboardBehaviorTrigger>
{
    public bool Equals(KeyboardBehaviorTrigger? x, KeyboardBehaviorTrigger? y)
    {
        if (x == null && y == null)
            return true;
        if (x == null || y == null)
            return false;

        return x.PlatformKey == y.PlatformKey && x.PlatformModifiers == y.PlatformModifiers;
    }

    public int GetHashCode(KeyboardBehaviorTrigger obj)
    {
        unchecked
        {
            int hash = 17;
            hash = hash * 23 + obj.Key.GetHashCode();
            hash = hash * 23 + obj.PlatformModifiers.GetHashCode();
            return hash;
        }
    }
}
#endif