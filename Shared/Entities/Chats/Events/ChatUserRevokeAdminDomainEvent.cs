using Shared.Entities.Users;
using Shared.Primitives;

namespace Shared.Entities.Chats.Events
{
    public record ChatUserRevokeAdminDomainEvent(Chat e, EUser revoker, EUser target) : DomainEvent(e)
    {
    }
}
