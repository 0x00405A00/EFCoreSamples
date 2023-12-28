using Shared.Primitives;

namespace Shared.Entities.Users.Events
{
    public record UserLoggedInDomainEvent(EUser e) : DomainEvent(e)
    {
    }
}
