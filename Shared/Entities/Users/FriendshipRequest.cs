using Shared.Primitives;

namespace Shared.Entities.Users
{
    public sealed class FriendshipRequest : Entity<FriendshipRequestId>
    {
        public UserId RequestUserForeignKey { get; set; }
        public UserId TargetUserForeignKey { get; set; }
        public UserId CreatedByUserForeignKey { get; set; }

        public User RequestUser { get; private set; }
        public User TargetUser { get; private set; }
        public User CreatedByUser { get; private set; }

        public string? TargetUserRequestMessage { get; private set; }
        public CustomDateTime? CreatedTime { get; private set; }

        //public ICollection<User> Users { get; } = new List<User>();

        public FriendshipRequest() 
        { 

        }
    }
}
