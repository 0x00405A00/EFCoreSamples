using Shared.Primitives;
using Shared.ValueObjects.Ids;

namespace Shared.Entities.Users
{
    public sealed partial class UserHasRelationToFriend : Entity<UserHasRelationToFriendId>
    {
        public UserId UserForeignKey { get; private set; }
        public UserId UserFriendForeignKey { get; private set; }

        private UserHasRelationToFriend() : base() 
        {

        }
    }
    public sealed partial class UserHasRelationToFriend
    {
        public User User { get; set; }
        public User UserFriend { get; set; }
    }
}
