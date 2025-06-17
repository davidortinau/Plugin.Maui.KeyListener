using Microsoft.Maui.Controls;

namespace Plugin.Maui.KeyListener.Sample;

public class FocusableContentView : ContentView
{
    public FocusableContentView()
    {
        this.Focused += OnFocused;
        this.GestureRecognizers.Add(new TapGestureRecognizer
        {
            NumberOfTapsRequired = 1,
            Command = new Command(async () =>
            {
                await this.Window.Page.DisplayAlert("Tapped", "Tapped", "OK");
            })
        });
    }

	void OnFocused(object sender, FocusEventArgs e)
	{
	}
}