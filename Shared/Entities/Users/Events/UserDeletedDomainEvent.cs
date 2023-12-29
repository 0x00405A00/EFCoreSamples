using Shared.Primitives;

namespace Shared.Entities.Users.Events
{
    public record UserDeletedDomainEvent(User e) : DomainEvent(e)
    {
    }
}
