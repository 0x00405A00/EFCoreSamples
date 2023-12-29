using Shared.Primitives;

namespace Shared.Entities.Users.Events
{
    public record UserRemoveFriendshipRequestDomainEvent : DomainEvent
    {
        private User user;
        private FriendshipRequest request;

        public UserRemoveFriendshipRequestDomainEvent(User User, FriendshipRequest Request) : base(User)
        {
            user = User;
            request = Request;
        }
    }
}