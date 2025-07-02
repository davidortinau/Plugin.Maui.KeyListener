//using Foundation;

using  Plugin.Maui.KeyListener;

namespace Plugin.Maui.KeyListener.Sample;

public partial class NavigableContentView : FocusableContentView
{
	#region Properties
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

	#endregion


	public NavigableContentView()
	{
		InitializeComponent();

		LastKeyPressed = "Start Value";
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