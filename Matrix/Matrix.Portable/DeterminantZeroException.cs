using System;

namespace Matrix.Portable
{
    public class DeterminantZeroException : Exception
    {
        public DeterminantZeroException() : base()
        {
        }

        public DeterminantZeroException(string message) : base(message)
        {
        }
    }
}