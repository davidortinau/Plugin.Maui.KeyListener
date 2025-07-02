namespace Plugin.Maui.KeyListener;

using Microsoft.Maui.Handlers;

public static partial class MauiProgramExtensions
{
	public static MauiAppBuilder UseKeyListener(this MauiAppBuilder builder)
	{
		SetupPlatformKeyListener(builder);
		return builder;
	}

	static partial void SetupPlatformKeyListener(MauiAppBuilder builder);
}