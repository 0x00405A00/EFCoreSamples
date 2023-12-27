using Shared.Entities.Roles;
using Shared.Primitives;
using Shared.ValueObjects.Ids;

namespace Shared.Entities.Users
{
    public sealed class UserHasRelationToRole : Entity<UserHasRelationToRoleId>
    {
        public UserId UserForeignKey { get; private set; }
        public RoleId RoleForeignKey { get; private set; }
        public EUser User { get; set; }
        public Role Role { get; set; }

        private UserHasRelationToRole() : base()
        {

        }
    }
}
