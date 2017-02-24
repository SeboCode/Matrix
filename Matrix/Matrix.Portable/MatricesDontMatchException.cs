using System;

namespace Matrix.Portable
{
    public class MatricesDontMatchException : Exception
    {
        public MatricesDontMatchException(string message) : base(message)
        {
        }
    }
}