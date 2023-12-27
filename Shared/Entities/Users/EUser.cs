using Shared.Entities.Roles;
using Shared.Primitives;
using Shared.ValueObjects.Ids;

namespace Shared.Entities.Users
{
    public class EUser : AuditableEntity<UserId>
    {
        public UserId? CreatedByUserForeignKey { get; set; }
        public UserId? LastModifiedByUserForeignKey { get; set; }
        public UserId? DeletedByUserForeignKey { get; set; }
        public EUser? CreatedByUser { get; set; }
        public EUser? LastModifiedByUser { get; set; }
        public EUser? DeletedByUser { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public UserTypeId UserTypeId { get; set; }//<------- FK
        public UserType UserType { get; set; }//<---- Navigation Property
        public ICollection<UserHasRelationToRole> UserHasRelationToRoles { get; }
        public ICollection<Role> Roles { get; }
        public virtual ICollection<UserType>? CreatedUserTypes { get; }
        public virtual ICollection<UserType>? ModifiedUserTypes { get; }
        public virtual ICollection<UserType>? DeletedUserTypes { get; }

        public virtual ICollection<Role>? CreatedRoles { get; }
        public virtual ICollection<Role>? ModifiedRoles { get; }
        public virtual ICollection<Role>? DeletedRoles { get; }

        //public ICollection<UserFriend> UserFriends { get; } = new List<UserFriend>();
        //public ICollection<FriendshipRequest> FriendshipRequests { get; } = new List<FriendshipRequest>();
        private EUser() : base()
        {

        }
        private EUser(
            UserId userId,
            string name,
            string email,
            string password,
            UserTypeId userTypeId,
            CustomDateTime createdDateTime,
            UserId createdBy,
            CustomDateTime? modifiedDateTime,
            UserId? modifiedBy,
            CustomDateTime? deletedDateTime,
            UserId? deletedBy)
        {
            Id = userId;
            Name = name;
            Email = email;
            Password = password;
            UserTypeId = userTypeId;
            CreatedTime = createdDateTime;
            CreatedByUserForeignKey = createdBy;
            LastModifiedTime = modifiedDateTime;
            LastModifiedByUserForeignKey = modifiedBy;
            DeletedTime = deletedDateTime;
            DeletedByUserForeignKey = deletedBy;
        }
        public static EUser Create(
            UserId userId,
            string name,
            string email,
            string password,
            UserTypeId userTypeId,
            CustomDateTime createdDateTime,
            UserId createdBy,
            CustomDateTime? modifiedDateTime,
            UserId? modifiedBy,
            CustomDateTime? deletedDateTime,
            UserId? deletedBy)
        {
            return new EUser(
                userId,
                name,
                email,
                password,
                userTypeId,
                createdDateTime,
                createdBy,
                modifiedDateTime,
                modifiedBy,
                deletedDateTime,
                deletedBy);
        }
    }
}
