using Shared.Entities.Users;
using Shared.Primitives;

namespace Shared.Entities.Chats.Events
{
    public record ChatUserAssignAdminChatDomainEvent(Chat e, User assigner, User target) : DomainEvent(e)
    {
    }
}
