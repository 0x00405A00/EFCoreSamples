using Shared.Primitives;

namespace Shared.Entities.Users.Events
{
    public record UserActivatedDomainEvent(EUser e) : DomainEvent(e)
    {

    }
}
