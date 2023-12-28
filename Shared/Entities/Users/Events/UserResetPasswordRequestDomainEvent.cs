using Shared.Primitives;

namespace Shared.Entities.Users.Events
{
    public record UserPasswordResetCompletedDomainEvent(EUser e) : DomainEvent(e)
    {
    }
}