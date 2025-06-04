using Plugin.Maui.KeyListener;
namespace Plugin.Maui.KeyListener.Sample;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	void ClearButton_Clicked(object sender, EventArgs e)
	{
		OutputLabel1.Text = string.Empty;
		OutputLabel2.Text = string.Empty;
		EntryTester1.Text = string.Empty;
		EntryTester2.Text = string.Empty;
	}

	void OnKeyDown_Entry1(object sender, KeyPressedEventArgs e)
	{
		string newValue = $"KeyPressed= {e.Keys}, Modifiers={e.Modifiers}";
		EntryTester1.Text = newValue;
		OutputLabel1.Text = newValue + Environment.NewLine + OutputLabel1.Text;
		e.Handled = true;
	}

	void OnKeyDown_Entry2(object sender, KeyPressedEventArgs e)
	{
		string newValue = $"KeyPressed= {e.Keys}, Modifiers={e.Modifiers}";
		EntryTester2.Text = newValue;
		OutputLabel2.Text = newValue + Environment.NewLine + OutputLabel2.Text;
		e.Handled = true;
	}
}