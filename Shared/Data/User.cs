namespace Shared.Data
{
    public class User : Entity<UserId>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public UserTypeId UserTypeId { get; set; }//<------- FK
        public virtual UserType UserType { get; set; }//<---- Navigation Property
        public virtual ICollection<UserHasRelationToRole> UserHasRelationToRoles { get; } = new List<UserHasRelationToRole>();
        public virtual ICollection<Role> Roles { get; } = new List<Role>();

        public User() 
        { 

        }

    }
    public record UserId : Identification
    {
        public UserId(Guid guid) : base(guid)
        {
        }
    }
}
