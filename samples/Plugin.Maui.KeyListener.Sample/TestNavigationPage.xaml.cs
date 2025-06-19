using Plugin.Maui.KeyListener;

namespace Plugin.Maui.KeyListener.Sample;

public partial class TestNavigationPage : ContentPage
{
    private static int _instanceCount = 0;
    private readonly int _instanceId;

    public TestNavigationPage()
    {
        InitializeComponent();
        _instanceId = ++_instanceCount;
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
        EventsLabel.Text = $"[Navigation#{_instanceId}] {eventName}: {e.Key}" + Environment.NewLine + EventsLabel.Text;
    }

    async void NavigateToTransientPage_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//transient");
    }

    async void NavigateToSingletonPage_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//singleton");
    }

    async void BackToMain_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//main");
    }

    void ClearEvents_Clicked(object sender, EventArgs e)
    {
        EventsLabel.Text = string.Empty;
    }
}