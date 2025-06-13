namespace Plugin.Maui.KeyListener;

public class KeyboardBehaviorTriggers : List<KeyboardBehaviorTrigger> { }

public partial class KeyboardBehaviorTrigger
{
    KeyboardModifiers _modifiers;
    KeyboardKeys _key;

    public KeyboardModifiers Modifiers
    {
        get => _modifiers;

        set
        {
            _modifiers = value;

            SetPlatformModifiers(_modifiers);

        }
    }

    public KeyboardKeys Key
    {
        get => _key;

        set
        {
            _key = value;

			SetPlatformKeys(_key);

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

    /// <summary>
    /// Sets the modifiers for the platform
    /// </summary>
    /// <param name="modifiers"></param>
    partial void SetPlatformModifiers(KeyboardModifiers modifiers);

    /// <summary>
    /// Sets the modifiers for the platform
    /// </summary>
    /// <param name="key"></param>
    partial void SetPlatformKeys(KeyboardKeys key);
}