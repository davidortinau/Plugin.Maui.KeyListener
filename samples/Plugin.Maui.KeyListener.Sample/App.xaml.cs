namespace Plugin.Maui.KeyListener.Sample;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

	}

	protected override Window CreateWindow(IActivationState activationState)
	{
		var shell = new AppShell();
		return new Window(shell);
	}
}