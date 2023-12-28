using Shared.Entities.Users;
using Shared.Primitives;
using Shared.ValueObjects.Ids;

namespace Shared.Entities.Chats
{
    public sealed partial class Message :AuditableEntity<MessageId>
    {
        public ChatId ChatForeignKey { get; private set; }
        public UserId UserForeignKey { get; private set; }
        public string Text { get; private set; }
        public string BinaryContentPath { get; private set; }
        public string BinaryContentPathFileExtension { get; private set; }
        public string BinaryContentBase64 { get; private set; }
        public string BinaryContentBase64MimeType { get; private set; }

        private Message() :base()
        {

        }
        private Message(MessageId messageId) 
        {
            Id = messageId;
        }

        public static Message Create(MessageId messageId)
        {
            return new Message(messageId);
        }
    }

    public sealed partial class Message
    {
        public Chat Chat { get; }
        public EUser User { get; }
        public ICollection<MessageOutbox>? MessagesInOutbox { get; }
    }

}
