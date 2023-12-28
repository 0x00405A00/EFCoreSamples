using Shared.Primitives;

namespace Shared.Entities.Users.Events
{
    public record UserBlockUserDomainEvent(EUser e, EUser blockedUser) : DomainEvent(e)
    {
    }
}
