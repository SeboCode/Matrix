using System;

namespace Matrix.Portable
{
    public class SquareMatrix : Matrix
    {
        public override double this[int row, int column]
        {
            set
            {
                base[row, column] = value;
                _determinantCalculated = false;
                _isInverseMatrixCalculated = false;
            }
        }

        public SquareMatrix(double[,] array) : base(array)
        {
            if (!IsSquare)
            {
                throw new ArgumentException(nameof(array));
            }
        }

        private bool _determinantCalculated = false;
        private double _determinant;
        public double Determinant => _determinantCalculated ? _determinant : (_determinant = CalculateDeterminant());

        private double CalculateDeterminant()
        {
            if (ColumnCount == 1)
            {
                return _matrix[0, 0];
            }

            var determinant = 0;
            _determinantCalculated = true;
            return determinant;
        }

        private bool _isInverseMatrixCalculated = false;
        private SquareMatrix _inverseMatrix;
        public SquareMatrix InverseMatrix => _isInverseMatrixCalculated ? _inverseMatrix : (_inverseMatrix = CalculateInverseMatrix());

        private SquareMatrix CalculateInverseMatrix()
        {
            if (Math.Abs(Determinant) < 0.0000000001)
            {
                throw new DeterminantZeroException();
            }

            _isInverseMatrixCalculated = true;
            throw new NotImplementedException();
        }

        public SquareMatrix SubMatrix(Point topLeft, int size)
        {
            var bottomRight = new Point(topLeft.X + size, topLeft.Y + size);
            return SubMatrix(topLeft, bottomRight).ToSquareMatrix();
        }
    }
}
