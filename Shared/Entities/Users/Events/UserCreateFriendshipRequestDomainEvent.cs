using Shared.Primitives;

namespace Shared.Entities.Users.Events
{
    public record UserCreateFriendshipRequestDomainEvent : DomainEvent
    {
        private EUser user;
        private FriendshipRequest request;

        public UserCreateFriendshipRequestDomainEvent(EUser user, FriendshipRequest request) : base(user)
        {
            this.user = user;
            this.request = request;
        }
    }
}