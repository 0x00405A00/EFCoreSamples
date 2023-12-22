namespace Shared.Data
{
    public class UserHasRelationToRole : Entity<UserHasRelationToRoleId>
    {
        public UserId UserForeignKey { get; set; }
        public RoleId RoleForeignKey { get; set; }
        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
        public UserHasRelationToRole()
        {
            
        }
    }
    public record UserHasRelationToRoleId : Identification
    {
        public UserHasRelationToRoleId(Guid guid) : base(guid)
        {
            
        }
    }
}
