using System.Runtime.Serialization;

namespace Shared.Entities.Users.Exceptions
{
    public class UserAlreadyDeletedException : System.Exception
    {
        public UserAlreadyDeletedException()
        {
        }

        public UserAlreadyDeletedException(string? message) : base(message)
        {
        }

        public UserAlreadyDeletedException(string? message, System.Exception? innerException) : base(message, innerException)
        {
        }

    }
}