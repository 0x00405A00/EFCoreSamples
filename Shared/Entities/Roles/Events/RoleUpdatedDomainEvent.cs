using Shared.Primitives;

namespace Shared.Entities.Roles.Events
{
    public record RoleUpdatedDomainEvent(Role e) : DomainEvent(e)
    {
    }
}
