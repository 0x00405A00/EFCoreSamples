using Shared.Primitives;
using Shared.ValueObjects.Ids;

namespace Shared.Entities.Users
{
    public sealed class FriendshipRequest : Entity<FriendshipRequestId>
    {
        public UserId RequestUserForeignKey { get; private set; }
        public UserId TargetUserForeignKey { get; private set; }
        public UserId CreatedByUserForeignKey { get; private set; }

        public EUser RequestUser { get; set; }
        public EUser TargetUser { get; set; }
        public EUser CreatedByUser { get; set; }

        public string? TargetUserRequestMessage { get; private set; }

        //public ICollection<User> Users { get; } = new List<User>();

        private FriendshipRequest() : base() 
        { 

        }
    }
}
