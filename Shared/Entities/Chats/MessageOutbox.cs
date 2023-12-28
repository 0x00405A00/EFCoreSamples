using Shared.Entities.Users;
using Shared.Primitives;
using Shared.ValueObjects.Ids;

namespace Shared.Entities.Chats
{
    public sealed partial class MessageOutbox : Entity<MessageOutboxId>
    {
        public MessageId MessageForeignKey { get; private set; }
        public UserId UserForeignKey { get; private set; }

        private MessageOutbox() : base()
        {

        }
        private MessageOutbox(MessageOutboxId messageId)
        {
            Id = messageId;
        }

        public static MessageOutbox Create(MessageOutboxId messageOutboxId)
        {
            return new MessageOutbox(messageOutboxId);
        }
    }
    public sealed partial class MessageOutbox
    {
        public Message Message { get; }
        public EUser User { get; }
    }
}
