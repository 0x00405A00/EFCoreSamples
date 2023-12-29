using Shared.Primitives;

namespace Shared.Entities.Users.Events
{
    public record UserCreateFriendshipRequestDomainEvent : DomainEvent
    {
        private User user;
        private FriendshipRequest request;

        public UserCreateFriendshipRequestDomainEvent(User user, FriendshipRequest request) : base(user)
        {
            this.user = user;
            this.request = request;
        }
    }
}