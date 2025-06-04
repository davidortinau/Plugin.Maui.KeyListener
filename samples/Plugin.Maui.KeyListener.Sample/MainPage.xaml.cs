using Plugin.Maui.KeyListener;

namespace Plugin.Maui.KeyListener.Sample;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
		
		AddKeyboardBehavior();
	}

	void AddKeyboardBehavior()
	{
		var keyboardBehavior = new KeyboardBehavior();
		keyboardBehavior.KeyDown += (sender, args) => PrependOutput("KeyDown", args);
		keyboardBehavior.KeyUp += (sender, args) => PrependOutput("KeyUp", args);
		this.Behaviors.Add(keyboardBehavior);
	}

	void PrependOutput(string eventName, KeyPressedEventArgs e)
	{
		OutputLabel.Text = $"{eventName}: {e.Modifiers} {e.Key} {e.KeyChar}" + Environment.NewLine + OutputLabel.Text;
	}

	void ClearButton_Clicked(object sender, EventArgs e)
	{
		OutputLabel.Text = string.Empty;
	}
}
