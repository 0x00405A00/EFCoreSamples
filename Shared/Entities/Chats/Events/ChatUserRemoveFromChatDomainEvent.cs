using Shared.Entities.Users;
using Shared.Primitives;

namespace Shared.Entities.Chats.Events
{
    public record ChatUserRemoveFromChatDomainEvent(Chat e, User execUser, User target) : DomainEvent(e)
    {
    }
}
