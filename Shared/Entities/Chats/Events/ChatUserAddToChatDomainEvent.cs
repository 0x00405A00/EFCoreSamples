using Shared.Entities.Users;
using Shared.Primitives;

namespace Shared.Entities.Chats.Events
{
    public record ChatUserAddToChatDomainEvent(Chat e, User execUser, User target) : DomainEvent(e)
    {
    }
}
