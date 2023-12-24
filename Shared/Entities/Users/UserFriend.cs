using Shared.Primitives;

namespace Shared.Entities.Users
{
    public sealed class UserFriend : Entity<UserFriendId>
    {
        public UserId UserForeignKey { get; set; }
        public UserId FriendForeignKey { get; set; }

        public User User { get; private set; }
        public User Friend { get; private set; }

        //public ICollection<User> Users { get; } = new List<User>();

        public UserFriend() 
        {

        }
    }
}
