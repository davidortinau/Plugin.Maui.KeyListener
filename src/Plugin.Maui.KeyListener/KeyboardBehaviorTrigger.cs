namespace Plugin.Maui.KeyListener;

public sealed class KeyboardBehaviorTriggers : List<KeyboardBehaviorTrigger> { }

public sealed partial class KeyboardBehaviorTrigger
{
    KeyboardModifiers _modifiers;
    KeyboardKeys _key;

    public KeyboardModifiers Modifiers
    {
        get => _modifiers;

        set
        {
            _modifiers = value;
#if MACCATALYST || WINDOWS
            SetPlatformModifiers(_modifiers);
#endif
        }
    }

    public KeyboardKeys Key
    {
        get => _key;

        set
        {
            _key = value;
#if MACCATALYST || WINDOWS
			SetPlatformKeys(_key);
#endif
		}
	}

    public override bool Equals(object? obj)
    {
        if (obj is not KeyboardBehaviorTrigger trigger)
            return false;

        return Key == trigger.Key && Modifiers == trigger.Modifiers;
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hash = 17;
            hash = hash * 23 + Key.GetHashCode();
            hash = hash * 23 + Modifiers.GetHashCode();
            return hash;
        }
    }
}