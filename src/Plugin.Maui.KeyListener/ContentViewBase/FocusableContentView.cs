using Microsoft.Maui.Controls;

namespace Plugin.Maui.KeyListener;

public partial class FocusableContentView : ContentView
{
    public FocusableContentView()
    {
        Focused += OnFocused;
        Loaded += OnLoaded;

        GestureRecognizers.Add(new TapGestureRecognizer
        {
            NumberOfTapsRequired = 1,
            Command = new Command(async () =>
            {
                Focus();
            })
        });

        //The control will not get keyboard focus without this.
        AutomationProperties.SetIsInAccessibleTree(this, true);
	}

    void OnLoaded(object sender, EventArgs e)
    {
	    OnPlatformLoaded(sender, e);
    }

    void OnFocused(object sender, FocusEventArgs e)
    {
	    OnPlatformFocused(sender, e);
    }

    partial void OnPlatformLoaded(object sender, EventArgs e);

	partial void OnPlatformFocused(object sender, FocusEventArgs e);
}

