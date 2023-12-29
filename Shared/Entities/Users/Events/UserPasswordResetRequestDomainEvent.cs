using Shared.Primitives;

namespace Shared.Entities.Users.Events
{
    public record UserPasswordResetRequestDomainEvent(User e) : DomainEvent(e)
    {

    }
}