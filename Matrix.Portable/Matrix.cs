using System;

namespace Matrix.Portable
{
    public class Matrix
    {

	    private int _columnCount;
	    private int _rowCount;
	    private double[][] _matrix;

	    public double this[int column, int row]
	    {
		    get
		    {
			    if (column >= 0 && row >= 0 && column < _columnCount && row < _rowCount)
				{
					return _matrix[column][row];
				}

			    throw new ArgumentException(nameof(_matrix));
		    }
			set {
				if (column >= 0 && row >= 0 && column < _columnCount && row < _rowCount)
				{
					_matrix[column][row] = value;
				}
			}
		}
    }
}
