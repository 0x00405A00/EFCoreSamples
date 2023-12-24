using Shared.Primitives;

namespace Shared.Entities.Users
{
    public record UserId : Identification
    {
        public UserId(Guid guid) : base(guid)
        {
        }
    }
}
