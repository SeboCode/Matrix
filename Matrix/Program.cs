using System;

namespace Matrix
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var matrix = new Portable.Matrix<int>(new[] {2, 3, 2, 5}, new[] {8, 6, 4, 9});
			Console.WriteLine(matrix);
			Console.ReadKey();
		}
	}
}
