using System.Runtime.Serialization;

namespace Shared.Entities.Users.Exceptions
{
    [Serializable]
    public class InvalidActivationTry : System.Exception
    {
        public InvalidActivationTry()
        {
        }

        public InvalidActivationTry(string? message) : base(message)
        {
        }

        public InvalidActivationTry(string? message, System.Exception? innerException) : base(message, innerException)
        {
        }

        protected InvalidActivationTry(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}