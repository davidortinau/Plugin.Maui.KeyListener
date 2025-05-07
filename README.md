
![](nuget.png)
# Plugin.Maui.KeyListener

`Plugin.Maui.KeyListener` provides `KeyboardBehavior` to listen for keyboard up (pressed) and down (released) events on any view in a .NET MAUI application. This is useful in situations where a `KeyboardAccelerator` isn't suitable.

> **Current status:** I've got macOS working, and Windows via global window events. Android and iOS need some love.

## Install Plugin

[![NuGet](https://img.shields.io/nuget/v/Plugin.Maui.KeyListener.svg?label=NuGet)](https://www.nuget.org/packages/Plugin.Maui.KeyListener/)

Available on [NuGet](http://www.nuget.org/packages/Plugin.Maui.KeyListener).

Install with the dotnet CLI: `dotnet add package Plugin.Maui.KeyListener`, or through the NuGet Package Manager in Visual Studio.

### Supported Platforms

| Platform | Minimum Version Supported |
|----------|---------------------------|
| iOS      | 11+                       |
| macOS    | 10.15+                    |
| Android  | 5.0 (API 21)              |
| Windows  | 11 and 10 version 1809+   |

## Accessibility Considerations

### Windows

Implementing KeyboardBehavior to manage navigation and interaction on Windows enhances accessibility because Windows accessibility features are tightly integrated with keyboard navigation. This allows users who rely on keyboard input rather than mouse interactions to navigate your application effectively.


### Mac

Using KeyboardBehavior on macOS improves navigation for users who have enabled basic keyboard navigation features. However, it provides no benefits for users utilizing Full Keyboard Access mode or VoiceOver screen reader navigation. For comprehensive accessibility support on Mac (and Windows), it's recommended to implement the SemanticOrderView from the MAUI Community Toolkit alongside KeyboardBehavior.


## API Usage

`Plugin.Maui.KeyListener` provides the `Feature` class that has a single property `Property` that you can get or set.

You can either use it as a static class, e.g.: `Feature.Default.Property = 1` or with dependency injection: `builder.Services.AddSingleton<IFeature>(Feature.Default);`

### Regisgtration

Before you can start using `KeyboardBehavior`, you need to register to use it in your `MauiProgram`:

```csharp
public static MauiApp CreateMauiApp()
{
    var builder = MauiApp.CreateBuilder();
    builder
        .UseMauiApp<App>()
        .UseKeyListener();    

    return builder.Build();
}
```

### Listening

Add the behavior to the visual element where you want to listen for keyboard events. These events will bubble up no matter where you have focus.

```csharp
public class MainPage : ContentPage
{
    KeyboardBehavior keyboardBehavior = new ();
    
    protected override void OnNavigatedTo(NavigatedToEventArgs args)
	{
		keyboardBehavior.KeyDown += OnKeyDown;
		keyboardBehavior.KeyUp += OnKeyUp;
		this.Behaviors.Add(keyboardBehavior);

		base.OnNavigatedTo(args);
	}

	protected override void OnNavigatedFrom(NavigatedFromEventArgs args)
	{
        keyboardBehavior.KeyDown -= OnKeyDown;
		keyboardBehavior.KeyUp -= OnKeyUp;
		this.Behaviors.Remove(keyboardBehavior);

		base.OnNavigatedFrom(args);
	}

    void OnKeyUp(object sender, KeyPressedEventArgs args)
    {
        // do something
    }

    void OnKeyDown(object sender, KeyPressedEventArgs args)
    {
        // do something
    }
}
```

# Sample

There is a sample project here in the repository. I've also built a little game [GuessWord](https://www.github.com/davidortinau/GuessWord) that uses this plugin.

# Acknowledgements

This is almost all code from @pureween, with some additions by @davidortinau and contributors! <3
