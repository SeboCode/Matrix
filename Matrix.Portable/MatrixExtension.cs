using System;

namespace Matrix.Portable
{
	public static class MatrixExtension
	{
		public static void ForEach<T>(this T[] source, Action<T> action)
		{
			if (source == null)
			{
				throw new ArgumentNullException(nameof(source));
			}

			if (action == null)
			{
				throw new ArgumentNullException(nameof(action));
			}

			foreach (var item in source)
			{
				action(item);
			}
		}
	}
}