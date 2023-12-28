using Shared.Primitives;

namespace Shared.Entities.Users.Events
{
    public record UserRemoveFriendshipRequestDomainEvent : DomainEvent
    {
        private EUser user;
        private FriendshipRequest request;

        public UserRemoveFriendshipRequestDomainEvent(EUser User, FriendshipRequest Request) : base(User)
        {
            user = User;
            request = Request;
        }
    }
}