using Shared.Primitives;

namespace Shared.ValueObjects.Ids
{
    public record UserTypeId : Identification
    {
        public UserTypeId(Guid guid) : base(guid)
        {

        }
    }
}
