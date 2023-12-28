using Shared.Primitives;

namespace Shared.Entities.Users.Events
{
    public record UserPasswordResetRequestDomainEvent(EUser e) : DomainEvent(e)
    {

    }
}