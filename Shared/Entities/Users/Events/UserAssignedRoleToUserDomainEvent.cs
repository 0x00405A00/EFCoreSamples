using Shared.Entities.Roles;
using Shared.Primitives;

namespace Shared.Entities.Users.Events
{
    public record UserAssignedRoleToUserDomainEvent(EUser assigner, EUser assignUser, Role assignedRole) : DomainEvent(assignUser)
    {
    }
}
