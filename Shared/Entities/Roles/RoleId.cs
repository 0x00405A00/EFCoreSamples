using Shared.Primitives;

namespace Shared.Entities.Roles
{
    public record RoleId : Identification
    {
        public RoleId(Guid guid) : base(guid)
        {

        }
    }
}
