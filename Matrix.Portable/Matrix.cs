using System;

namespace Matrix.Portable
{
	public class Matrix : ICloneable
	{

		private readonly double[][] _matrix;

		public double this[int column, int row]
		{
			get
			{
				if (column < 0 || row < 0 || column >= ColumnCount || row >= RowCount)
				{
					throw new IndexOutOfRangeException(nameof(_matrix));
				}

				return _matrix[column][row];
			}
			private set
			{
				if (column < 0 || row < 0 || column >= ColumnCount || row >= RowCount)
				{
					throw new IndexOutOfRangeException(nameof(_matrix));
				}

				_matrix[column][row] = value;
			}
		}

		public Matrix(params double[][] columns)
		{
			if (columns == null)
			{
				throw new ArgumentNullException(nameof(columns));
			}

			if (columns.Length < 1)
			{
				throw new ArgumentException(nameof(columns));
			}

			if (columns[0].Length < 1)
			{
				throw new ArgumentException(nameof(columns));
			}

			for (var i = 1; i < columns.Length; i++)
			{
				if (columns[i].Length != columns[i - 1].Length)
				{
					throw new ArgumentException(nameof(columns));
				}
			}

			_matrix = new double[columns.Length][];
			Array.Copy(columns, _matrix, columns.Length);
		}

		private Matrix(int columnSize, int rowSize)
		{
			_matrix = new double[columnSize][];

			for (var i = 0; i < ColumnCount; i++)
			{
				_matrix[i] = new double[rowSize];
			}
		}

		public int ColumnCount => _matrix.Length;

		public int RowCount => _matrix[0].Length;

		public bool IsSquare => ColumnCount == RowCount;

		private bool _isInverseMatrixCalculated = false;
		private Matrix _inverseMatrix;

		public Matrix InverseMatrix
			=> _isInverseMatrixCalculated ? _inverseMatrix : (_inverseMatrix = CalculateInverseMatrix());

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
			if (matrix.ColumnCount != matrix2.ColumnCount || matrix.RowCount != matrix2.RowCount)
			{
				// todo implement own exception
				throw new Exception();
			}
			
			var returnMatrix = new Matrix(matrix.ColumnCount, matrix.RowCount);

			for (var i = 0; i < matrix.ColumnCount; i++)
			{
				for (var x = 0; x < matrix.RowCount; x++)
				{
					returnMatrix[i, x] = matrix[i, x] + matrix2[i, x];
				}
			}

			return returnMatrix;
		}

		public static Matrix operator +(Matrix matrix, int skalar)
		{
			var returnMatrix = new Matrix(matrix.ColumnCount, matrix.RowCount);

			for (var i = 0; i < matrix.ColumnCount; i++)
			{
				for (var x = 0; x < matrix.RowCount; x++)
				{
					returnMatrix[i, x] = matrix[i, x] + skalar;
				}
			}

			return returnMatrix;
		}

		public override string ToString()
		{
			var str = string.Empty;

			_matrix.ForEach(column =>
			{
				column.ForEach(element => str += $"{element} ");
				str += "\r\n";
			});

			return str;
		}
	}
}
