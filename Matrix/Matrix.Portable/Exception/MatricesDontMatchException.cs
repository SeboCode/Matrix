namespace Matrix.Portable.Exception
{
    public class MatricesDontMatchException : System.Exception
    {
        public MatricesDontMatchException() : base()
        {
        }

        public MatricesDontMatchException(string message) : base(message)
        {
        }
    }
}