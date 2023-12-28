using Shared.Primitives;

namespace Shared.Entities.Users.Events
{
    public record UserRemoveFriendDomainEvent(EUser user, EUser newFriend) : DomainEvent(user)
    {
    }
}
