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

        private bool _isInverseMatrixCalculated = false;
        private Matrix _inverseMatrix;
        public Matrix InverseMatrix => _isInverseMatrixCalculated ? _inverseMatrix : (_inverseMatrix = CalculateInverseMatrix());

        private Matrix CalculateInverseMatrix()
        {
            _isInverseMatrixCalculated = true;
            throw new NotImplementedException();
        }
    }
}
