using System;
using System.Drawing;

namespace Matrix.Portable
{
    public class Matrix : ICloneable
    {
        private readonly double[,] _matrix;

        public virtual double this[int row, int column]
        {
            get
            {
                if (row < 0 || column < 0 || row >= RowCount || column >= ColumnCount)
                {
                    throw new IndexOutOfRangeException(nameof(_matrix));
                }

                return _matrix[row, column];
            }
            set
            {
                if (row < 0 || column < 0 || row >= RowCount || column >= ColumnCount)
                {
                    throw new IndexOutOfRangeException(nameof(_matrix));
                }

                _matrix[row, column] = value;
            }
        }

        public Matrix(double[,] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.GetLength(0) == 0)
            {
                throw new ArgumentException(nameof(array));
            }

            if (array.GetLength(1) == 0)
            {
                throw new ArgumentException(nameof(array));
            }

            _matrix = array;
        }

        public int RowCount => _matrix.GetLength(0);

        public int ColumnCount => _matrix.GetLength(1);

        public bool IsSquare => RowCount == ColumnCount;

        /// <summary>
        /// Get a submatrix.
        /// </summary>
        /// <remarks>
        /// The X element of the point is used for the row and the Y for the column
        /// </remarks>
        /// <param name="topLeft">Including topleft point</param>
        /// <param name="bottomRight">Excluding bottomright point</param>
        /// <returns>The submatrix as a new matrix instance</returns>
        public Matrix SubMatrix(Point topLeft, Point bottomRight)
        {
            if (topLeft.X < 0 || topLeft.Y < 0 || topLeft.X > RowCount - 1 || topLeft.Y > ColumnCount - 1)
            {
                throw new ArgumentException(nameof(topLeft));
            }

            if (bottomRight.X < 1 || bottomRight.Y < 1 || bottomRight.X > RowCount || bottomRight.Y > ColumnCount)
            {
                throw new ArgumentException(nameof(bottomRight));
            }

            var values = new double[bottomRight.X - topLeft.X, bottomRight.Y - topLeft.Y];

            for (var x = topLeft.X; x < bottomRight.X; x++)
            {
                for (var y = topLeft.Y; y < bottomRight.Y; y++)
                {
                    values[x, y] = _matrix[x, y];
                }
            }

            return new Matrix(values);
        }

        public bool SameSize(Matrix matrix)
        {
            if (matrix == null)
            {
                return false;
            }

            return RowCount == matrix.RowCount && ColumnCount == matrix.ColumnCount;
        }

        public SquareMatrix ToSquareMatrix()
        {
            return new SquareMatrix(_matrix);
        }

        public object Clone()
        {
            throw new NotImplementedException();
        }

        public static Matrix operator +(Matrix matrix, Matrix matrix2)
        {
            if (matrix.SameSize(matrix2))
            {
                throw new MatricesDontMatchException($"{nameof(matrix)} and {nameof(matrix2)} don't match for an addition");
            }

            var values = new double[matrix.RowCount, matrix.ColumnCount];

            for (var x = 0; x < matrix.RowCount; x++)
            {
                for (var y = 0; y < matrix.ColumnCount; y++)
                {
                    values[x, y] = matrix[x, y] + matrix2[x, y];
                }
            }

            return new Matrix(values);
        }

        public static Matrix operator +(Matrix matrix, double skalar)
        {
            var values = new double[matrix.RowCount, matrix.ColumnCount];

            for (var x = 0; x < matrix.RowCount; x++)
            {
                for (var y = 0; y < matrix.ColumnCount; y++)
                {
                    values[x, y] = matrix[x, y] + skalar;
                }
            }

            return new Matrix(values);
        }

        public static Matrix operator -(Matrix matrix, Matrix matrix2)
        {
            if (matrix.SameSize(matrix2))
            {
                throw new MatricesDontMatchException($"{nameof(matrix)} and {nameof(matrix2)} don't match for a subtraction");
            }

            var values = new double[matrix.RowCount, matrix.ColumnCount];

            for (var x = 0; x < matrix.RowCount; x++)
            {
                for (var y = 0; y < matrix.ColumnCount; y++)
                {
                    values[x, y] = matrix[x, y] - matrix2[x, y];
                }
            }

            return new Matrix(values);
        }

        public static Matrix operator -(Matrix matrix, double skalar)
        {
            var values = new double[matrix.RowCount, matrix.ColumnCount];

            for (var x = 0; x < matrix.RowCount; x++)
            {
                for (var y = 0; y < matrix.ColumnCount; y++)
                {
                    values[x, y] = matrix[x, y] - skalar;
                }
            }

            return new Matrix(values);
        }

        public static Matrix operator *(Matrix matrix, Matrix matrix2)
        {
            if (matrix.RowCount != matrix2.ColumnCount)
            {
                throw new MatricesDontMatchException($"{nameof(matrix)} and {nameof(matrix2)} don't match for a multiplication");
            }

            var values = new double[matrix.RowCount, matrix2.ColumnCount];

            for (var x = 0; x < matrix.RowCount; x++)
            {
                for (var j = 0; j < matrix2.ColumnCount; j++)
                {
                    for (var y = 0; y < matrix2.RowCount; y++)
                    {
                        values[x, j] += matrix[x, y] * matrix2[y, j];
                    }
                }
            }

            return new Matrix(values);
        }

        public static Matrix operator *(Matrix matrix, double skalar)
        {
            var values = new double[matrix.RowCount, matrix.ColumnCount];

            for (var x = 0; x < matrix.RowCount; x++)
            {
                for (var y = 0; y < matrix.ColumnCount; y++)
                {
                    values[x, y] += matrix[x, y] * skalar;
                }
            }

            return new Matrix(values);
        }

        public override string ToString()
        {
            var str = string.Empty;

            for (var x = 0; x < RowCount; x++)
            {
                for (var y = 0; y < ColumnCount; y++)
                {
                    str += $"{_matrix[x, y]}\t";
                }

                if (x != RowCount - 1)
                {
                    str += "\r\n";
                }
            }

            return str;
        }
    }
}
