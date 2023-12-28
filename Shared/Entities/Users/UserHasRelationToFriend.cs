using Shared.Primitives;
using Shared.ValueObjects.Ids;

namespace Shared.Entities.Users
{
    public sealed class UserHasRelationToFriend : Entity<UserHasRelationToFriendId>
    {
        public UserId UserForeignKey { get; private set; }
        public UserId UserFriendForeignKey { get; private set; }

        public EUser User { get; set; }
        public EUser UserFriend { get; set; }

        private UserHasRelationToFriend() : base() 
        {

        }
    }
}
