using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#if WINDOWS
using Microsoft.UI.Xaml;
#endif


namespace Plugin.Maui.KeyListener.Sample.Controls;

public partial class NavigableUserControl : ContentView
{
	public static readonly BindableProperty TextProperty =
		BindableProperty.Create(nameof(Text),
			typeof(string),
			typeof(NavigableUserControl),
			string.Empty);

	public string Text
	{
		get => (string)GetValue(TextProperty);
		set => SetValue(TextProperty, value);
	}


	public static readonly BindableProperty LastKeyPressedProperty =
		BindableProperty.Create(nameof(LastKeyPressed),
			typeof(string),
			typeof(NavigableUserControl),
			string.Empty);

	public string LastKeyPressed
	{
		get => (string)GetValue(LastKeyPressedProperty);
		set => SetValue(LastKeyPressedProperty, value);
	}

	public static readonly BindableProperty FocusStateTextProperty =
		BindableProperty.Create(nameof(FocusStateText),
			typeof(string),
			typeof(NavigableUserControl),
			string.Empty);


	public string FocusStateText
	{
		get => (string)GetValue(FocusStateTextProperty);
		set => SetValue(FocusStateTextProperty, value);
	}




	public NavigableUserControl()
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
	}

	public void OnKeyDown(object sender, KeyPressedEventArgs e)
	{
		LastKeyPressed = $"Key={e.Keys}, Modifiers={e.Modifiers}";
		e.Handled = false;
	}

	protected void OnTapped(object sender, TappedEventArgs e)
	{
		Focus();
	}



}