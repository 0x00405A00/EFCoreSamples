using Shared.Entities.Users;
using Shared.Primitives;

namespace Shared.Entities.Chats.Events
{
    public record ChatUserAssignAdminChatDomainEvent(Chat e, EUser assigner, EUser target) : DomainEvent(e)
    {
    }
}
