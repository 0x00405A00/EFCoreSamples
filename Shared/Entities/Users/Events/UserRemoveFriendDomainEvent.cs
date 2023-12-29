using Shared.Primitives;

namespace Shared.Entities.Users.Events
{
    public record UserRemoveFriendDomainEvent(User user, User newFriend) : DomainEvent(user)
    {
    }
}
