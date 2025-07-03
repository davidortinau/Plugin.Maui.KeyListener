namespace Plugin.Maui.KeyListener;

[ContentProperty(nameof(Modifiers))]
public sealed class KeyboardModifiersExtension : IMarkupExtension
{
	public string Modifiers { get; set; }

	public object ProvideValue(IServiceProvider serviceProvider)
	{
		if (Enum.TryParse(typeof(KeyboardModifiers), Modifiers, out object enumValue))
		{
			return enumValue;
		}

		IEnumerable<string> enumValues = Modifiers.Split(',').Select(flag => flag.Trim());
		KeyboardModifiers combinedFlag = KeyboardModifiers.None;

		foreach (string flag in enumValues)
		{
			if (Enum.TryParse(typeof(KeyboardModifiers), flag, out object singleFlag))
			{
				combinedFlag |= (KeyboardModifiers)singleFlag;
			}
		}

		return combinedFlag;
	}
}

[ContentProperty(nameof(Keys))]
public sealed class KeyboardKeysExtension : IMarkupExtension
{
	public string Keys { get; set; }

	public object ProvideValue(IServiceProvider serviceProvider)
	{
		return Enum.TryParse(typeof(KeyboardKeys), Keys, out object enumValue) ? enumValue : KeyboardKeys.None;
	}
}
