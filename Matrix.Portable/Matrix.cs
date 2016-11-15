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

			if (!rows.Any())
			{
				throw new ArgumentException(nameof(rows));
			}

			if (!rows.First().Any())
			{
				throw new ArgumentException(nameof(rows));
			}

			for (var x = 1; x < rows.Count(); x++)
			{
				if (rows[x].Count() != rows[x - 1].Count())
				{
					throw new ArgumentException(nameof(rows));
				}
			}

			_matrix = new double[rows.Count()][];
			Array.Copy(rows, _matrix, RowCount);
		}

		private Matrix(int rowCount, int columnCount)
		{
			if (rowCount < 1)
			{
				throw new ArgumentException(nameof(rowCount));
			}

			if (columnCount < 1)
			{
				throw new ArgumentException(nameof(columnCount));
			}

			_matrix = new double[rowCount][];

			for (var x = 0; x < RowCount; x++)
			{
				_matrix[x] = new double[columnCount];
			}
		}

		public int RowCount => _matrix.Count();

		public int ColumnCount => _matrix.First().Count();

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

			for (var x = 0; x < matrix.RowCount; x++)
			{
				for (var y = 0; y < matrix.ColumnCount; y++)
				{
					returnMatrix[x, y] = matrix[x, y] + matrix2[x, y];
				}
			}

			return returnMatrix;
		}

		public static Matrix operator +(Matrix matrix, double skalar)
		{
			var returnMatrix = new Matrix(matrix.RowCount, matrix.ColumnCount);

			for (var x = 0; x < matrix.RowCount; x++)
			{
				for (var y = 0; y < matrix.ColumnCount; y++)
				{
					returnMatrix[x, y] = matrix[x, y] + skalar;
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

			for (var x = 0; x < matrix.RowCount; x++)
			{
				for (var j = 0; j < matrix2.ColumnCount; j++)
				{
					for (var y = 0; y < matrix2.RowCount; y++)
					{
						returnMatrix[x, j] += matrix[x, y] * matrix2[y, j];
					}
				}
			}

			return returnMatrix;
		}

		public static Matrix operator *(Matrix matrix, double skalar)
		{
			var returnMatrix = new Matrix(matrix.RowCount, matrix.ColumnCount);

			for (var x = 0; x < matrix.RowCount; x++)
			{
				for (var y = 0; y < matrix.ColumnCount; y++)
				{
					returnMatrix[x, y] += matrix[x, y] * skalar;
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
