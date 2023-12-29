using Shared.Primitives;

namespace Shared.Entities.Users.Events
{
    public record UserActivatedDomainEvent(User e) : DomainEvent(e)
    {

    }
}
