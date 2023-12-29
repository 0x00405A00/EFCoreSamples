using Shared.Primitives;

namespace Shared.Entities.Users.Events
{
    public record UserAddFriendDomainEvent(User e, User newFriend) : DomainEvent(e)
    {
    }
}
