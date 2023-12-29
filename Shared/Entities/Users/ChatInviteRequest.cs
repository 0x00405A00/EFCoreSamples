using Shared.Entities.Chats;
using Shared.Primitives;
using Shared.ValueObjects.Ids;

namespace Shared.Entities.Users
{
    public sealed partial class ChatInviteRequest : Entity<ChatInviteRequestId>
    {
        public ChatId ChatForeignKey { get; private set; }
        public UserId RequesterUserForeignKey { get; private set; }
        public UserId TargetUserForeignKey { get; private set; }

        public string? TargetUserRequestMessage { get; private set; }

        private ChatInviteRequest() : base()
        {

        }
        private ChatInviteRequest(ChatInviteRequestId userChatInviteRequestId)
        {
            Id = userChatInviteRequestId;
        }
    }

    public sealed partial class ChatInviteRequest
    {
        public Chat Chat { get; set; }
        public User RequesterUser { get; set; }
        public User TargetUser { get; set; }
    }
}
