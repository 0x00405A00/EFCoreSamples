using Shared.Primitives;

namespace Shared.Entities.Roles.Events
{
    public record RoleCreatedDomainEvent(Role e) : DomainEvent(e)
    {
    }
}
