using Shared.Entities.Users;
using Shared.Primitives;

namespace Shared.Entities.Roles
{
    public sealed class Role : Entity<RoleId>
    {
        public string Name { get; set; }
        public ICollection<UserHasRelationToRole> UserHasRelationToRoles { get; } = new List<UserHasRelationToRole>();
        public ICollection<User> Users { get; } = new List<User>();

        public Role()
        {

        }
    }
}
