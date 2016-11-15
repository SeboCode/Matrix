using System;
using System.Linq;

namespace Matrix.Portable
{
	public class Matrix : ICloneable
	{

		private readonly double[][] _matrix;

		public double this[int row, int column]
		{
			get
			{
				if (row < 0 || column < 0 || row >= RowCount || column >= ColumnCount)
				{
					throw new IndexOutOfRangeException(nameof(_matrix));
				}

				return _matrix[row][column];
			}
			private set
			{
				if (row < 0 || column < 0 || row >= RowCount || column >= ColumnCount)
				{
					throw new IndexOutOfRangeException(nameof(_matrix));
				}

				_matrix[row][column] = value;
			}
		}

		public Matrix(params double[][] rows)
		{
			if (rows == null)
			{
				throw new ArgumentNullException(nameof(rows));
			}

			if (rows.Length < 1)
			{
				throw new ArgumentException(nameof(rows));
			}

			if (rows[0].Length < 1)
			{
				throw new ArgumentException(nameof(rows));
			}

			for (var i = 1; i < rows.Length; i++)
			{
				if (rows[i].Length != rows[i - 1].Length)
				{
					throw new ArgumentException(nameof(rows));
				}
			}

			_matrix = new double[rows.Length][];
			Array.Copy(rows, _matrix, rows.Length);
		}

		private Matrix(int columnSize, int rowSize)
		{
			_matrix = new double[columnSize][];

			for (var i = 0; i < RowCount; i++)
			{
				_matrix[i] = new double[rowSize];
			}
		}

		public int RowCount => _matrix.Length;

		public int ColumnCount => _matrix[0].Length;

		public bool IsSquare => RowCount == ColumnCount;

		private bool _isInverseMatrixCalculated = false;
		private Matrix _inverseMatrix;
		public Matrix InverseMatrix => _isInverseMatrixCalculated ? _inverseMatrix : (_inverseMatrix = CalculateInverseMatrix());

		private Matrix CalculateInverseMatrix()
		{
			throw new NotImplementedException();
		}

		public object Clone()
		{
			throw new NotImplementedException();
		}

		public static Matrix operator +(Matrix matrix, Matrix matrix2)
		{
			if (matrix.RowCount != matrix2.RowCount || matrix.ColumnCount != matrix2.ColumnCount)
			{
				// todo implement own exception
				throw new Exception();
			}
			
			var returnMatrix = new Matrix(matrix.RowCount, matrix.ColumnCount);

			for (var i = 0; i < matrix.RowCount; i++)
			{
				for (var x = 0; x < matrix.ColumnCount; x++)
				{
					returnMatrix[i, x] = matrix[i, x] + matrix2[i, x];
				}
			}

			return returnMatrix;
		}

		public static Matrix operator +(Matrix matrix, double skalar)
		{
			var returnMatrix = new Matrix(matrix.RowCount, matrix.ColumnCount);

			for (var i = 0; i < matrix.RowCount; i++)
			{
				for (var x = 0; x < matrix.ColumnCount; x++)
				{
					returnMatrix[i, x] = matrix[i, x] + skalar;
				}
			}

			return returnMatrix;
		}

		public static Matrix operator *(Matrix matrix, Matrix matrix2)
		{
			if (matrix.RowCount != matrix2.ColumnCount)
			{
				// todo implement own exception
				throw new Exception();
			}

			var returnMatrix = new Matrix(matrix.RowCount, matrix2.ColumnCount);

			for (var i = 0; i < matrix.RowCount; i++)
			{
				for (var j = 0; j < matrix2.ColumnCount; j++)
				{
					for (var x = 0; x < matrix2.RowCount; x++)
					{
						returnMatrix[i, j] += matrix[i, x] * matrix2[x, j];
					}
				}
			}

			return returnMatrix;
		}

		public static Matrix operator *(Matrix matrix, double skalar)
		{
			var returnMatrix = new Matrix(matrix.RowCount, matrix.ColumnCount);

			for (var i = 0; i < matrix.RowCount; i++)
			{
				for (var x = 0; x < matrix.ColumnCount; x++)
				{
					returnMatrix[i, x] += matrix[i, x] * skalar;
				}
			}

			return returnMatrix;
		}

		public override string ToString()
		{
			var str = string.Empty;

			_matrix.ForEach(column =>
			{
				column.ForEach(element => str += $"{element}\t");

				if (column != _matrix.Last())
				{
					str += "\r\n";
				}
			});

			return str;
		}
	}
}
