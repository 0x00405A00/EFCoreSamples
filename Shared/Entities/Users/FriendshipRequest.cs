using Shared.Primitives;
using Shared.ValueObjects.Ids;

namespace Shared.Entities.Users
{
    public sealed class FriendshipRequest : Entity<FriendshipRequestId>
    {
        public UserId RequestUserForeignKey { get; set; }
        public UserId TargetUserForeignKey { get; set; }
        public UserId CreatedByUserForeignKey { get; set; }

        public EUser RequestUser { get; set; }
        public EUser TargetUser { get; set; }
        public EUser CreatedByUser { get; set; }

        public string? TargetUserRequestMessage { get; set; }
        public CustomDateTime? CreatedTime { get; set; }

        //public ICollection<User> Users { get; } = new List<User>();

        private FriendshipRequest() : base() 
        { 

        }
    }
}
