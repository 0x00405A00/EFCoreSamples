using Shared.Entities.Roles;
using Shared.Primitives;

namespace Shared.Entities.Users
{
    public sealed class User : Entity<UserId>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public UserTypeId UserTypeId { get; set; }//<------- FK
        public UserType UserType { get; set; }//<---- Navigation Property
        public ICollection<UserHasRelationToRole> UserHasRelationToRoles { get; } = new List<UserHasRelationToRole>();
        public ICollection<Role> Roles { get; } = new List<Role>();

        //public ICollection<UserFriend> UserFriends { get; } = new List<UserFriend>();
        //public ICollection<FriendshipRequest> FriendshipRequests { get; } = new List<FriendshipRequest>();

        public User()
        {

        }

    }
}
