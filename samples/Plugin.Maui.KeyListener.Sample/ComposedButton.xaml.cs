namespace Plugin.Maui.KeyListener.Sample;

public partial class ComposedButton : ContentPage
{
	public ComposedButton()
	{
		InitializeComponent();
		
	}

	void Button_Clicked(object sender, EventArgs e)
	{
		FocusableContentView1.Focus();
	}
}