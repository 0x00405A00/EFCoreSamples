using Shared.Primitives;

namespace Shared.Entities.Users
{
    public record FriendshipRequestId : Identification
    {
        public FriendshipRequestId(Guid Uuid) : base(Uuid)
        {
        }
    }
}
