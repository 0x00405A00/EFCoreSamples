using Shared.Entities.Users;
using Shared.Primitives;
using Shared.ValueObjects.Ids;

namespace Shared.Entities.Chats
{
    public sealed partial class ChatRelationToUser : AuditableEntity<ChatRelationToUserId>
    {
        public UserId UserForeignKey { get; private set; }
        public ChatId ChatForeignKey { get; private set; }
        public bool? IsChatAdmin { get; private set; }

        private ChatRelationToUser():base()
        {
        
        }
    }
    public sealed partial class ChatRelationToUser
    {
        public EUser User { get; }
        public Chat Chat { get; }
    }
}
