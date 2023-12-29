using Shared.Entities.Users;
using Shared.Primitives;

namespace Shared.Entities.Chats.Events
{
    public record ChatUserRevokeAdminDomainEvent(Chat e, User revoker, User target) : DomainEvent(e)
    {
    }
}
