namespace Plugin.Maui.KeyListener
{
	public partial class KeyboardBehavior : PlatformBehavior<VisualElement>
	{
		public bool UsePreviewEvents { get; set; }

		public event EventHandler<KeyPressedEventArgs> KeyDown;
		public event EventHandler<KeyPressedEventArgs> KeyUp;

		internal void RaiseKeyDown(KeyPressedEventArgs args) => KeyDown?.Invoke(this, args);
		internal void RaiseKeyUp(KeyPressedEventArgs args) => KeyUp?.Invoke(this, args);
	}
}
