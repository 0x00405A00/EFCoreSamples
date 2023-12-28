using Shared.Entities.Roles;
using Shared.Primitives;
using Shared.ValueObjects.Ids;

namespace Shared.Entities.Users
{
    public sealed partial class UserHasRelationToRole : Entity<UserHasRelationToRoleId>
    {
        public UserId UserForeignKey { get; private set; }
        public RoleId RoleForeignKey { get; private set; }

        private UserHasRelationToRole() : base()
        {

        }
    }
    public sealed partial class UserHasRelationToRole
    {
        public EUser User { get; set; }
        public Role Role { get; set; }
    }
}
