<!-- 
Everything in here is of course optional. If you want to add/remove something, absolutely do so as you see fit.
This example README has some dummy APIs you'll need to replace and only acts as a placeholder for some inspiration that you can fill in with your own functionalities.
-->
![](nuget.png)
# Plugin.Maui.KeyListener

`Plugin.Maui.KeyListener` provides `KeyboardBehavior` to listen for keyboard up (pressed) and down (released) events on any view in a .NET MAUI application. This is useful in situations where a `KeyboardAccelerator` isn't suitable.

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

# Acknowledgements

This is almost all code from@pureween, with some additions by moi! <3
