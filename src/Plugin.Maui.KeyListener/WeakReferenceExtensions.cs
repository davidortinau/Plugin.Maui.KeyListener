using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugin.Maui.KeyListener;

internal static class WeakReferenceExtensions
{
	public static bool WeakReferenceEquals<T>(this WeakReference<T> weakRef, T target) where T : class
	{
		return weakRef.TryGetTarget(out var currentTarget) && ReferenceEquals(currentTarget, target);
	}
}
