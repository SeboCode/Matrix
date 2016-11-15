using System;

namespace Matrix
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var matrix = new Matrix.Portable.Matrix(new double[] {2, 3, 2, 5}, new double[] {8, 6, 4, 9});
			Console.WriteLine(matrix);
			Console.ReadKey();
		}
	}
}
