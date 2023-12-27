using Shared.Entities.Roles;
using Shared.Primitives;
using Shared.ValueObjects.Ids;

namespace Shared.Entities.Users
{
    public class UserHasRelationToRole : Entity<UserHasRelationToRoleId>
    {
        public UserId UserForeignKey { get; set; }
        public RoleId RoleForeignKey { get; set; }
        public EUser User { get; set; }
        public Role Role { get; set; }

        private UserHasRelationToRole() : base()
        {

        }
    }
}
