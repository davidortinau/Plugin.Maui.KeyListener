namespace Plugin.Maui.KeyListener;

static class WeakReferenceExtensions
{
	public static bool WeakReferenceEquals<T>(this WeakReference<T> weakRef, T target) where T : class
	{
		return weakRef.TryGetTarget(out var currentTarget) && ReferenceEquals(currentTarget, target);
	}
}