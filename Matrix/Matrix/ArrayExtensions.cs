using System;
using System.Linq;

namespace Matrix
{
	public static class ArrayExtensions
	{
		public static T[] Fill<T>(this T[] source, T value)
		{
			if (source == null)
			{
				throw new ArgumentNullException(nameof(source));
			}

			for (var i = 0; i < source.Count(); i++)
			{
				source[i] = value;
			}

			return source;
		}
	}
}
