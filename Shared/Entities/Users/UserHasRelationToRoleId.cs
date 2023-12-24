using Shared.Primitives;

namespace Shared.Entities.Users
{
    public record UserHasRelationToRoleId : Identification
    {
        public UserHasRelationToRoleId(Guid guid) : base(guid)
        {

        }
    }
}
