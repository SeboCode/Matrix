using System;

namespace Matrix
{
	public class Program
	{
		private readonly Portable.Matrix _matrix;
		private readonly Portable.Matrix _matrix2;
		private readonly Portable.Matrix _matrix3;

		private Program()
		{
			_matrix = new Portable.Matrix(new double[] { 2, -1, 2 }, new double[] { -2, 3, 1 });
			_matrix2 = new Portable.Matrix(new[] { 2.5, 3.4, 2.2 }, new[] { 8.5, 6.4, 4 });
			_matrix3 = new Portable.Matrix(new double[] { -3, 2 }, new double[] { 2, 1 }, new double[] { 3, -1 });
		}

		public void PrintMatrix()
		{
			Console.WriteLine("Matrix1");
			Console.WriteLine(_matrix);
			Console.WriteLine();
			Console.WriteLine("Matrix2");
			Console.WriteLine(_matrix2);
			Console.WriteLine();
			Console.WriteLine("Matrix3");
			Console.WriteLine(_matrix3);
		}

		public void PrintAdd()
		{
			Console.WriteLine("Add:");
			Console.WriteLine("Matrix1 + 5 =");
			Console.WriteLine(_matrix + 5);
			Console.WriteLine();
			Console.WriteLine("Matrix1 + Matrix2 =");
			Console.WriteLine(_matrix + _matrix2);
		}

		public void PrintMulti()
		{
			Console.WriteLine("Multi");
			Console.WriteLine("Matrix1 * 5 = ");
			Console.WriteLine(_matrix * 5);
			Console.WriteLine();
			Console.WriteLine("Matrix1 * Matrix3 =");
			Console.WriteLine(_matrix * _matrix3);
		}

		public static void Main(string[] args)
		{
			var program = new Program();
			program.PrintMatrix();
			Console.WriteLine("------------------------------------");
			program.PrintAdd();
			Console.WriteLine("------------------------------------");
			program.PrintMulti();
			Console.ReadKey();
		}
	}
}
