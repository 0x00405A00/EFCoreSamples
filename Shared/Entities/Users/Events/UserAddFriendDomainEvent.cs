using Shared.Primitives;

namespace Shared.Entities.Users.Events
{
    public record UserAddFriendDomainEvent(EUser e, EUser newFriend) : DomainEvent(e)
    {
    }
}
