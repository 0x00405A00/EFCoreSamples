using Shared.Primitives;

namespace Shared.Entities.Users.Events
{
    public record UserBlockUserDomainEvent(User e, User blockedUser) : DomainEvent(e)
    {
    }
}
