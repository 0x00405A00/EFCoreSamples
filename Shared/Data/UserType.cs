
namespace Shared.Data
{
    public class UserType : Entity<UserTypeId>
    {
        public string Name { get; set; }
        public virtual ICollection<User> Users { get; set; } = new List<User>();
        public UserType()
        {
            
        }
    }
    public record UserTypeId : Identification
    {
        public UserTypeId(Guid guid) : base(guid)
        {

        }
    }
}
