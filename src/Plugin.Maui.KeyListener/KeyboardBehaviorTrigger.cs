namespace Plugin.Maui.KeyListener;

/// <summary>
/// Placeholder for future keyboard trigger functionality.
/// Currently not used in the library, but reserved for advanced keyboard shortcut or trigger scenarios.
/// </summary>
public class KeyboardBehaviorTriggers : List<KeyboardBehaviorTrigger>
{
}

/// <summary>
/// Placeholder for a keyboard trigger definition.
/// Not currently used, but reserved for future expansion to support custom keyboard triggers or shortcuts.
/// </summary>
public partial class KeyboardBehaviorTrigger
{
	KeyboardModifiers _modifiers;
	KeyboardKeys _key;

	/// <summary>
	/// Gets or sets the keyboard modifier(s) for this trigger.
	/// </summary>
	public KeyboardModifiers Modifiers
	{
		get => _modifiers;
		set
		{
			_modifiers = value;
			SetPlatformModifiers(_modifiers);
		}
	}

	/// <summary>
	/// Gets or sets the keyboard key for this trigger.
	/// </summary>
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
		{
			return false;
		}

		return this.Key == trigger.Key && this.Modifiers == trigger.Modifiers;
	}

	public override int GetHashCode()
	{
		unchecked
		{
			int hash = 17;
			hash = hash * 23 + this.Key.GetHashCode();
			hash = hash * 23 + this.Modifiers.GetHashCode();
			return hash;
		}
	}

	/// <summary>
	/// Platform-specific partial method for setting modifiers.
	/// </summary>
	partial void SetPlatformModifiers(KeyboardModifiers modifiers);

	/// <summary>
	/// Platform-specific partial method for setting keys.
	/// </summary>
	partial void SetPlatformKeys(KeyboardKeys key);
}