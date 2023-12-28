using Shared.Primitives;

namespace Shared.Entities.Users.Events
{
    public record UserCreatedDomainEvent(EUser e) : DomainEvent(e)
    {

    }
}
