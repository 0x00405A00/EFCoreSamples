using System.Runtime.Serialization;

namespace Shared.Entities.Mail.Exceptions
{
    public class AttachmentAlreadyExistsException : System.Exception
    {
        public AttachmentAlreadyExistsException()
        {
        }

        public AttachmentAlreadyExistsException(string? message) : base(message)
        {
        }


        public AttachmentAlreadyExistsException(string? message, System.Exception? innerException) : base(message, innerException)
        {
        }

        protected AttachmentAlreadyExistsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}