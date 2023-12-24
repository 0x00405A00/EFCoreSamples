using Shared.Entities.Roles;
using Shared.Primitives;

namespace Shared.Entities.Users
{
    public sealed class UserHasRelationToRole : Entity<UserHasRelationToRoleId>
    {
        public UserId UserForeignKey { get; set; }
        public RoleId RoleForeignKey { get; set; }
        public User User { get; set; }
        public Role Role { get; set; }
        public UserHasRelationToRole()
        {

        }
    }
}
