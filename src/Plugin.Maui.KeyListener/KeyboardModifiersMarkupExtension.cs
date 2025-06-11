namespace Plugin.Maui.KeyListener;

[ContentProperty(nameof(Modifiers))]
public sealed class KeyboardModifiersMarkupExtension : IMarkupExtension
{
    public string Modifiers { get; set; }

    public object ProvideValue(IServiceProvider serviceProvider)
    {
        if (Enum.TryParse(typeof(KeyboardModifiers), Modifiers, out var enumValue))
        {
            return enumValue;
        }

        var enumValues = Modifiers.Split(',').Select(flag => flag.Trim());
        var combinedFlag = KeyboardModifiers.None;

        foreach (var flag in enumValues)
        {
            if (Enum.TryParse(typeof(KeyboardModifiers), flag, out var singleFlag))
                combinedFlag |= (KeyboardModifiers)singleFlag;
        }

        return combinedFlag;
    }
}
