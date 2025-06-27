#if MACCATALYST

using Foundation;
using Microsoft.Maui.Platform;
using UIKit;

namespace Plugin.Maui.KeyListener;

public class KeyboardPageViewController : PageViewController
{
	readonly List<WeakReference<KeyboardBehavior>> keyboardBehaviors = new();

	internal KeyboardPageViewController(IView page, IMauiContext mauiContext)
		: base(page, mauiContext)
	{
	}

	public override bool CanBecomeFirstResponder => true;

	public override void PressesBegan(NSSet<UIPress> presses, UIPressesEvent evt)
	{
		if (ProcessPresses(presses, evt, false))
		{
			return;
		}

		base.PressesBegan(presses, evt);
	}

	public override void PressesCancelled(NSSet<UIPress> presses, UIPressesEvent evt)
	{
		if (ProcessPresses(presses, evt, true))
		{
			return;
		}

		base.PressesCancelled(presses, evt);
	}

	public override void PressesEnded(NSSet<UIPress> presses, UIPressesEvent evt)
	{
		if (ProcessPresses(presses, evt, true))
		{
			return;
		}

		base.PressesEnded(presses, evt);
	}

	internal void RegisterKeyboardBehavior(KeyboardBehavior keyboardBehavior)
	{
		if (keyboardBehaviors.Any(weakRef => weakRef.WeakReferenceEquals(keyboardBehavior)))
		{
			return;
		}

		keyboardBehaviors.Add(new WeakReference<KeyboardBehavior>(keyboardBehavior));
	}

	internal void UnregisterKeyboardBehavior(KeyboardBehavior keyboardBehavior)
	{
		foreach (var weakRef in keyboardBehaviors)
		{
			if (weakRef.WeakReferenceEquals(keyboardBehavior))
			{
				keyboardBehaviors.Remove(weakRef);
				break;
			}
		}
	}

	void CleanupTargets()
	{
		keyboardBehaviors.RemoveAll(weakRef => !weakRef.TryGetTarget(out var target));
	}

	bool ProcessPresses(NSSet<UIPress> presses, UIPressesEvent evt, bool isKeyUp)
	{
		CleanupTargets();

		if (keyboardBehaviors.Count == 0)
		{
			return false;
		}

		var modifiers = evt.ModifierFlags.ToVirtualModifiers();
		var handled = false;

		foreach (var press in presses)
		{
			if (press.Key is not UIKey key)
			{
				continue;
			}

			var keyEnum = key.KeyCode.ToKeyboardKeys();
			var eventArgs = new KeyPressedEventArgs
			{
				Modifiers = modifiers,
				Keys = keyEnum,
				KeyName = keyEnum.ToString() 
			};

			foreach (var weakBehavior in keyboardBehaviors)
			{
				if (weakBehavior.TryGetTarget(out var target) && target is not null)
				{
					//only route events to behaviors that are associated with a visual element or their children
					if (target.ScopedElement == null ||
					    ContainsFocus(target.ScopedElement) == false)
					{
						continue;
					}

					if (isKeyUp)
					{
						target.RaiseKeyUp(eventArgs);
					}
					else
					{
						target.RaiseKeyDown(eventArgs);
					}

					if (eventArgs.Handled)
					{
						handled = true;
						break;
					}
				}
			}
		}

		return handled;
	}

	bool ContainsFocus(VisualElement? element)
	{
		if (element == null)
		{
			return false;
		}

		// Include self
		if (element.IsFocused)
		{
			return true;
		}

		// Check all visual tree descendants
		return element
			.GetVisualTreeDescendants()
			.OfType<VisualElement>()
			.Any(x => x.IsFocused);
	}
}
#endif