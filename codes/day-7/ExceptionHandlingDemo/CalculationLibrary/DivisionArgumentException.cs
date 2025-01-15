namespace CalculationLibrary
{
    //public class DivisionArgumentException : ApplicationException
    //{
    //    public DivisionArgumentException() : base("Invalid argument in divide method")
    //    {

    //    }
    //    public DivisionArgumentException(string message) : base(message)
    //    {
    //    }
    //}
    public class DivisionArgumentException : ApplicationException
    {
        string _message;
        public DivisionArgumentException()
        {
            _message = "Invalid argument in divide method";
        }
        public DivisionArgumentException(string message)
        {
            _message = message;
        }

        public override string Message =>_message;
    }
}
