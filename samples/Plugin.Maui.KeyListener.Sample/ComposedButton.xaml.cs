namespace Plugin.Maui.KeyListener.Sample;

public partial class ComposedButton : ContentPage
{
	public ComposedButton()
	{
		InitializeComponent();
		FocusableContentView1.Focused += FocusableContentView1_Focused;
		this.Loaded += ComposedButton_Loaded;
		
	}

	void ComposedButton_Loaded(object sender, EventArgs e)
	{
		FocusableContentView1.Focus();
	}

	void FocusableContentView1_Focused(object sender, FocusEventArgs e)
	{
			
	}

	void Button_Clicked(object sender, EventArgs e)
	{
		FocusableContentView1.Focus();
	}
}