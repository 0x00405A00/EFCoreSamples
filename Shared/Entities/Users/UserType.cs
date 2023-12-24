using Shared.Primitives;

namespace Shared.Entities.Users
{
    public sealed class UserType : Entity<UserTypeId>
    {
        public string Name { get; set; }
        public ICollection<User> Users { get; set; } = new List<User>();
        public UserType()
        {

        }
    }
}
