using Shared.Primitives;

namespace Shared.Entities.Users
{
    public record UserTypeId : Identification
    {
        public UserTypeId(Guid guid) : base(guid)
        {

        }
    }
}
