using Shared.Primitives;

namespace Shared.Entities.Users.Events
{
    public record UserLoggedInDomainEvent(User e) : DomainEvent(e)
    {
    }
}
