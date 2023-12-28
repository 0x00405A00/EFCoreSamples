using Shared.Entities.Roles;
using Shared.Primitives;

namespace Shared.Entities.Users.Events
{
    public record UserRevokedRoleToUserDomainEvent(EUser revoker, EUser revokeUser, Role revokedRole) : DomainEvent(revokeUser)
    {
    }
}
