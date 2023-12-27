using Shared.Primitives;

namespace Shared.ValueObjects.Ids
{
    public record UserFriendId : Identification
    {
        public UserFriendId(Guid Uuid) : base(Uuid)
        {
        }
    }
}
