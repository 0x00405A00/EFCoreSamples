using Shared.Primitives;
using Shared.ValueObjects.Ids;

namespace Shared.Entities.Users
{
    public sealed class UserHasRelationToFriend : Entity<UserHasRelationToFriendId>
    {
        public UserId UserForeignKey { get; private set; }
        public UserId UserFriendForeignKey { get; private set; }

        public User User { get; set; }
        public User UserFriend { get; set; }

        private UserHasRelationToFriend() : base() 
        {

        }
    }
}
