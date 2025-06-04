#if IOS || MACCATALYST

using Foundation;
using Microsoft.Maui.Platform;
using UIKit;

namespace Plugin.Maui.KeyListener
{
	public class KeyboardPageViewController : PageViewController
	{
		readonly List<WeakReference<KeyboardBehavior>> _keyboardBehaviors = new();

		internal KeyboardPageViewController(IView page, IMauiContext mauiContext)
			: base(page, mauiContext) { }

#if IOS // Workaround to allow receiving keys when the root page is a Shell
		public override bool CanBecomeFirstResponder => true;

		public override void ViewIsAppearing(bool animated)
		{
			base.ViewIsAppearing(animated);

			BecomeFirstResponder();
		}
#endif

		public override void PressesBegan(NSSet<UIPress> presses, UIPressesEvent evt)
		{
			if (ProcessPresses(presses, evt, false))
				return;

			base.PressesBegan(presses, evt);
		}

		public override void PressesCancelled(NSSet<UIPress> presses, UIPressesEvent evt)
		{
			if (ProcessPresses(presses, evt, true))
				return;

			base.PressesCancelled(presses, evt);
		}

		public override void PressesEnded(NSSet<UIPress> presses, UIPressesEvent evt)
		{
			if (ProcessPresses(presses, evt, true))
				return;

			base.PressesEnded(presses, evt);
		}

		internal void RegisterKeyboardBehavior(KeyboardBehavior keyboardBehavior)
		{
			if (_keyboardBehaviors.Any(weakRef => weakRef.WeakReferenceEquals(keyboardBehavior)))
				return;

			_keyboardBehaviors.Add(new WeakReference<KeyboardBehavior>(keyboardBehavior));
		}

		internal void UnregisterKeyboardBehavior(KeyboardBehavior keyboardBehavior)
		{
			foreach (var weakRef in _keyboardBehaviors)
			{
				if (weakRef.WeakReferenceEquals(keyboardBehavior))
				{
					_keyboardBehaviors.Remove(weakRef);
					break;
				}
			}
		}

		void CleanupTargets()
		{
			_keyboardBehaviors.RemoveAll(weakRef => !weakRef.TryGetTarget(out var target));
		}

		bool ProcessPresses(NSSet<UIPress> presses, UIPressesEvent evt, bool isKeyUp)
		{
			CleanupTargets();

			if (_keyboardBehaviors.Count == 0)
				return false;

			var modifiers = evt.ModifierFlags.ToVirtualModifiers();
			bool handled = false;

			foreach (var press in presses)
			{
				if (press.Key is not UIKey key)
					continue;

				var characters = key.Characters;
				var eventArgs = new KeyPressedEventArgs
				{
					Modifiers = modifiers,
					Key = key.KeyCode.ToKeyboardKeys(),
					KeyChar = characters.Length == 1 ? char.ToUpperInvariant(characters[0]) : default,
				};

				foreach (var weakBehavior in _keyboardBehaviors)
				{
					if (weakBehavior.TryGetTarget(out var target) && target is not null)
					{
						if (isKeyUp)
							target.RaiseKeyUp(eventArgs);
						else
							target.RaiseKeyDown(eventArgs);

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
	}
}
#endif