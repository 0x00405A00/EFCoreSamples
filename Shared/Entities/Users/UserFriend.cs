using Shared.Primitives;
using Shared.ValueObjects.Ids;

namespace Shared.Entities.Users
{
    public sealed class UserFriend : Entity<UserFriendId>
    {
        public UserId UserForeignKey { get; private set; }
        public UserId FriendForeignKey { get; private set; }

        public EUser User { get; set; }
        public EUser Friend { get; set; }

        //public ICollection<User> Users { get; } = new List<User>();

        private UserFriend() : base() 
        {

        }
    }
}
