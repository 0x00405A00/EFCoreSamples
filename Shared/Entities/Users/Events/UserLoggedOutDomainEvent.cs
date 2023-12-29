using Shared.Primitives;

namespace Shared.Entities.Users.Events
{
    public record UserLoggedOutDomainEvent(User e) : DomainEvent(e)
    {
    }
}
