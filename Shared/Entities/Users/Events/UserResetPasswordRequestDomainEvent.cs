using Shared.Primitives;

namespace Shared.Entities.Users.Events
{
    public record UserPasswordResetCompletedDomainEvent(User e) : DomainEvent(e)
    {
    }
}