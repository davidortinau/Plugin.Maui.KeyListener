namespace Plugin.Maui.KeyListener;

using UIKit;

public partial class KeyboardBehavior : PlatformBehavior<VisualElement>
{
	protected override void OnAttachedTo(VisualElement bindable, UIView platformView)
	{
		base.OnAttachedTo(bindable, platformView);

		ScopedElement = bindable;

		Page page = GetParentPage(bindable);

		// Register to key press events
		if (page?.Handler is not IPlatformViewHandler viewHandler ||
		    viewHandler.ViewController is not KeyboardPageViewController keyboardPageViewController)
		{
			return;
		}

		keyboardPageViewController.RegisterKeyboardBehavior(this);
	}

	protected override void OnDetachedFrom(VisualElement bindable, UIView platformView)
	{
		base.OnDetachedFrom(bindable, platformView);

		Page page = GetParentPage(bindable);


		// Unregister from key press events
		if (page?.Handler is not IPlatformViewHandler viewHandler ||
		    viewHandler.ViewController is not KeyboardPageViewController keyboardPageViewController)
		{
			return;
		}

		ScopedElement = null;

		keyboardPageViewController.UnregisterKeyboardBehavior(this);
	}

	private static Page? GetParentPage(VisualElement element)
	{
		if (element is Page)
		{
			return element as Page;
		}

		Element currentElement = element;

		while (currentElement != null && currentElement is not Page)
		{
			currentElement = currentElement.Parent;
		}

		return currentElement as Page;
	}
}