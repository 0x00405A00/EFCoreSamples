
namespace Shared.Data
{
    public class Role : Entity<RoleId>
    {
        public string Name { get; set; }
        public virtual ICollection<UserHasRelationToRole> UserHasRelationToRoles { get; } = new List<UserHasRelationToRole>();
        public virtual ICollection<User> Users { get; } = new List<User>();
        public Role()
        {
                
        }
    }
    public record RoleId : Identification
    {
        public RoleId(Guid guid) : base(guid)
        {

        }
    }
}
