using Plugin.Maui.KeyListener;

namespace Plugin.Maui.KeyListener.Sample;

public partial class SingletonTestPage : ContentPage
{
    private static int _instanceCount = 0;
    private readonly int _instanceId;
    private int _visitCount = 0;

    public SingletonTestPage()
    {
        InitializeComponent();
        _instanceId = ++_instanceCount;
        InstanceLabel.Text = $"Instance #{_instanceId} - Created at {DateTime.Now:HH:mm:ss}";
        AddKeyboardBehavior();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _visitCount++;
        VisitCountLabel.Text = $"Visit count: {_visitCount}";
        System.Diagnostics.Debug.WriteLine($"SingletonTestPage #{_instanceId} OnAppearing called (visit #{_visitCount})");
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
        EventsLabel.Text = $"[Singleton#{_instanceId}] {eventName}: {e.Key}" + Environment.NewLine + EventsLabel.Text;
    }

    async void BackToNavigation_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//navigation");
    }

    void ClearEvents_Clicked(object sender, EventArgs e)
    {
        EventsLabel.Text = string.Empty;
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        System.Diagnostics.Debug.WriteLine($"SingletonTestPage #{_instanceId} OnDisappearing called");
    }
}