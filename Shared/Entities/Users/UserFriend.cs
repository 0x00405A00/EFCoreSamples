using Shared.Primitives;
using Shared.ValueObjects.Ids;

namespace Shared.Entities.Users
{
    public class UserFriend : Entity<UserFriendId>
    {
        public UserId UserForeignKey { get; set; }
        public UserId FriendForeignKey { get; set; }

        public EUser User { get; set; }
        public EUser Friend { get; set; }

        //public ICollection<User> Users { get; } = new List<User>();

        private UserFriend() : base() 
        {

        }
    }
}
