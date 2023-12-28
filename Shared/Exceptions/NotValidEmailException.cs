namespace Shared.Exceptions
{
    public sealed class NotValidEmailException : System.Exception
    {
        public NotValidEmailException(string email)
            : base($"{email} is not valid")
        {

        }
    }
}
