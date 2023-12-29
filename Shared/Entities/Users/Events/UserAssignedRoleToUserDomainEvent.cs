using Shared.Entities.Roles;
using Shared.Primitives;

namespace Shared.Entities.Users.Events
{
    public record UserAssignedRoleToUserDomainEvent(User assigner, User assignUser, Role assignedRole) : DomainEvent(assignUser)
    {
    }
}
