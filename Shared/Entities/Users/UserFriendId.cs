using Shared.Primitives;

namespace Shared.Entities.Users
{
    public record UserFriendId : Identification
    {
        public UserFriendId(Guid Uuid) : base(Uuid)
        {
        }
    }
}
