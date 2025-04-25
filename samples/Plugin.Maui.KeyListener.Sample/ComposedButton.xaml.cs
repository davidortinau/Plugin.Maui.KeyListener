namespace Plugin.Maui.KeyListener.Sample;

public partial class ComposedButton : ContentPage
{
	public ComposedButton()
	{
		InitializeComponent();
		this.SemanticOrderView.ViewOrder = new List<View> { entry, entry2,FocusableContentView1, FCW2, entry1 };
		
	}

	void Button_Clicked(object sender, EventArgs e)
	{
		FocusableContentView1.Focus();
	}
}