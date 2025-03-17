namespace MP_NewSystem.Helper
{
    public class MPException : System.Exception
    {
        public MPException(string ErrorMessage)
        : base(string.Format("MPower Exception :: {0} ", ErrorMessage))
        { }
    }
}
