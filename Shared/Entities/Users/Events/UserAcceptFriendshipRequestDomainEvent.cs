using Shared.Primitives;

namespace Shared.Entities.Users.Events
{
    public record UserAcceptFriendshipRequestDomainEvent : DomainEvent
    {
        private EUser user;
        private FriendshipRequest request;

        public UserAcceptFriendshipRequestDomainEvent(EUser user, FriendshipRequest request) : base(user)
        {
            this.user = user;
            this.request = request;
        }
    }
}