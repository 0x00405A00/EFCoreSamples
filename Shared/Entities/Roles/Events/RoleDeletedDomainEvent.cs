using Shared.Primitives;

namespace Shared.Entities.Roles.Events
{
    public record RoleDeletedDomainEvent(Role e) : DomainEvent(e)
    {
    }
}
