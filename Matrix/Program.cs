using System;

namespace Matrix
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var matrix = new Portable.Matrix(new double[] { 2, 3, 2, 5 }, new double[] { 8, 6, 4, 9 });
			var matrix2 = new Portable.Matrix(new[] { 2.5, 3.4, 2.2, 5.8 }, new[] { 8.5, 6.4, 4.1, 9 });
			Console.WriteLine(matrix + 5);
			Console.ReadKey();
		}
	}
}
