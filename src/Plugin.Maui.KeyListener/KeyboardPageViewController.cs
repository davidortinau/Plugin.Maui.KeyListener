#if IOS || MACCATALYST

using Foundation;
using Microsoft.Maui.Platform;
using UIKit;

namespace Plugin.Maui.KeyListener
{
	public class KeyboardPageViewController : PageViewController
	{
		bool _hasRegistrations;
		readonly List<WeakReference<KeyboardBehavior>> _keyboardBehaviors = new List<WeakReference<KeyboardBehavior>>();

		internal KeyboardPageViewController(IView page, IMauiContext mauiContext)
			: base(page, mauiContext) { }

		public override void PressesBegan(NSSet<UIPress> presses, UIPressesEvent evt)
		{
			ProcessPressses(presses, evt, false);
			base.PressesBegan(presses, evt);
		}

		public override void PressesCancelled(NSSet<UIPress> presses, UIPressesEvent evt)
		{
			ProcessPressses(presses, evt, true);
			base.PressesCancelled(presses, evt);
		}

		public override void PressesEnded(NSSet<UIPress> presses, UIPressesEvent evt)
		{
			ProcessPressses(presses, evt, true);
			base.PressesEnded(presses, evt);
		}

		internal void RegisterKeyboardBehavior(KeyboardBehavior keyboardBehavior)
		{
			if (TryGetIndexOfKeyboardBehavior(keyboardBehavior))
				return;

			_keyboardBehaviors.Add(new WeakReference<KeyboardBehavior>(keyboardBehavior));
			_hasRegistrations = true;
		}

		internal void UnregisterKeyboardBehavior(KeyboardBehavior keyboardBehavior)
		{
			if (!TryGetIndexOfKeyboardBehavior(keyboardBehavior, out var index))
				return;

			_keyboardBehaviors.RemoveAt(index);

			if (!_keyboardBehaviors.Any())
				_hasRegistrations = false;
		}

		bool TryGetIndexOfKeyboardBehavior(KeyboardBehavior keyboardBehavior)
			=> TryGetIndexOfKeyboardBehavior(keyboardBehavior, out _);

		bool TryGetIndexOfKeyboardBehavior(KeyboardBehavior keyboardBehavior, out int index)
		{
			index = _keyboardBehaviors.FindIndex(weakRef =>
			{
				if (weakRef.TryGetTarget(out var target))
					return target == keyboardBehavior;

				return false;
			});

			return index >= 0;
		}

		void CleanupTargets()
		{
			var targetsToRemove = _keyboardBehaviors.Where(i => !i.TryGetTarget(out var target)).ToList();

			foreach (var target in targetsToRemove)
				_keyboardBehaviors.Remove(target);
		}

		void ProcessPressses(NSSet<UIPress> presses, UIPressesEvent evt, bool isKeyUp)
		{
			if (!_hasRegistrations)
				return;

			var targets = _keyboardBehaviors.Select(i => i.TryGetTarget(out var target) ? target : null).Where(i => i != null).ToList();

			if (targets.Count != _keyboardBehaviors.Count)
				CleanupTargets();

			if (targets.Count == 0)
				return;

			var firstTarget = targets.First();
			var modifiers = evt.ModifierFlags.ToVirtualModifiers();

			foreach (var press in presses)
			{
				if (press.Key is not UIKey key)
					continue;

				var characters = key.Characters;
				var eventArgs = new KeyPressedEventArgs
				{
					Modifiers = modifiers,
					Keys = key.KeyCode.ToKeyboardKeys(),
					KeyChar = characters.Length == 1 ? char.ToUpperInvariant(characters[0]) : default,
				};

				if (isKeyUp)
					firstTarget.RaiseKeyUp(eventArgs);
				else
					firstTarget.RaiseKeyDown(eventArgs);
			}
		}
	}
}
#endif