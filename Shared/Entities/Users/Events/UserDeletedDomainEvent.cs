using Shared.Primitives;

namespace Shared.Entities.Users.Events
{
    public record UserDeletedDomainEvent(EUser e) : DomainEvent(e)
    {
    }
}
