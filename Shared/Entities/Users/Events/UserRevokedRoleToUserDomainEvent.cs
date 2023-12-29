using Shared.Entities.Roles;
using Shared.Primitives;

namespace Shared.Entities.Users.Events
{
    public record UserRevokedRoleToUserDomainEvent(User revoker, User revokeUser, Role revokedRole) : DomainEvent(revokeUser)
    {
    }
}
