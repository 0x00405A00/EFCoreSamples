using Shared.Primitives;

namespace Shared.Entities.Users.Events
{
    public record UserCreatedDomainEvent(User e) : DomainEvent(e)
    {

    }
}
