using Shared.Primitives;
using Shared.ValueObjects.Ids;

namespace Shared.Entities.Users
{
    public sealed partial class FriendshipRequest : Entity<FriendshipRequestId>
    {
        public UserId RequestUserForeignKey { get; private set; }
        public UserId TargetUserForeignKey { get; private set; }

        public string? TargetUserRequestMessage { get; private set; }

        private FriendshipRequest() : base() 
        { 

        }
    }
    public sealed partial class FriendshipRequest
    {
        public EUser RequesterUser { get; set; }
        public EUser TargetUser { get; set; }
    }
}
