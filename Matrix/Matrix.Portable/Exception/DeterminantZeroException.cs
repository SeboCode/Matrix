namespace Matrix.Portable.Exception
{
    public class DeterminantZeroException : System.Exception
    {
        public DeterminantZeroException() : base()
        {
        }

        public DeterminantZeroException(string message) : base(message)
        {
        }
    }
}