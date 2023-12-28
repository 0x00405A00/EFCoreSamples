using Shared.Primitives;

namespace Shared.Entities.Users.Events
{
    public record UserLoggedOutDomainEvent(EUser e) : DomainEvent(e)
    {
    }
}
