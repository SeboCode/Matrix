using System;

namespace Matrix.Portable
{
    public class Matrix : ICloneable
    {
		
	    private double[][] _matrix;

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
			set
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

	    public int ColumnCount => _matrix.Length;

	    public int RowCount => _matrix[0].Length;

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
    }
}
