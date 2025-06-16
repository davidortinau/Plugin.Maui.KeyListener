//using Foundation;
#if MACCATALYST
using UIKit;
#endif

#if WINDOWS
using Microsoft.UI.Xaml;
#endif

namespace Plugin.Maui.KeyListener.Sample;

public partial class NavigableContentView : ContentView
{
	public static readonly BindableProperty TextProperty =
		BindableProperty.Create(nameof(Text),
			typeof(string),
			typeof(NavigableContentView),
			string.Empty);

	public string Text
	{
		get => (string)GetValue(TextProperty);
		set => SetValue(TextProperty, value);
	}


	public static readonly BindableProperty LastKeyPressedProperty =
		BindableProperty.Create(nameof(LastKeyPressed),
			typeof(string),
			typeof(NavigableContentView),
			string.Empty);

	public string LastKeyPressed
	{
		get => (string)GetValue(LastKeyPressedProperty);
		set => SetValue(LastKeyPressedProperty, value);
	}

	public static readonly BindableProperty FocusStateTextProperty =
		BindableProperty.Create(nameof(FocusStateText),
			typeof(string),
			typeof(NavigableContentView),
			string.Empty);


	public string FocusStateText
	{
		get => (string)GetValue(FocusStateTextProperty);
		set => SetValue(FocusStateTextProperty, value);
	}





	public NavigableContentView()
	{
		InitializeComponent();

		Loaded += OnLoaded;


		LastKeyPressed = "Start Value";
	}

	void OnLoaded(object? sender, EventArgs e)
	{
#if WINDOWS

		if (Handler?.PlatformView is FrameworkElement nativeElement)
		{
			nativeElement.IsTabStop = true;
		}
#endif
#if MACCATALYST
		if (Handler?.PlatformView is UIView nativeView)
		{
			nativeView.UserInteractionEnabled = true;
			nativeView.BecomeFirstResponder();
		}
#endif

		//TODO:  How do we make the Mac/IOS focusable ???
	}

	public void OnKeyDown(object sender, KeyPressedEventArgs e)
	{
		LastKeyPressed = $"Key={e.Keys}, Modifiers={e.Modifiers}";

		if (e.Keys == KeyboardKeys.Space)
		{
			SpaceKeyActivatedCheckbox.IsChecked = !SpaceKeyActivatedCheckbox.IsChecked;
		}
	}

	protected void OnTapped(object sender, TappedEventArgs e)
	{
		if (IsFocused == false)
		{
			Focus();
		}
	}
}