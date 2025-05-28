namespace Plugin.Maui.KeyListener;

[ContentProperty(nameof(Modifiers))]
public sealed class KeyboardModifiersExtension : IMarkupExtension
{
    public string Modifiers { get; set; }

    public object ProvideValue(IServiceProvider serviceProvider)
    {
        var combinedFlag = KeyboardModifiers.None;

        foreach (var range in MemoryExtensions.Split(Modifiers, ','))
        {
            var flag = Modifiers.AsSpan()[range].Trim();
            if (Enum.TryParse(typeof(KeyboardModifiers), flag, out var singleFlag))
                combinedFlag |= (KeyboardModifiers)singleFlag;
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
        return Enum.TryParse(typeof(KeyboardKeys), Keys, out var enumValue) ? enumValue : KeyboardKeys.None;
    }
}