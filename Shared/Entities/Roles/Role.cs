using Shared.Entities.Users;
using Shared.Primitives;
using Shared.ValueObjects.Ids;

namespace Shared.Entities.Roles
{
    public sealed class Role : AuditableEntity<RoleId>
    {
        public string Name { get; set; }
        public ICollection<UserHasRelationToRole> UserHasRelationToRoles { get; set; }
        public ICollection<EUser> Users { get; set; }
        private Role() : base()
        {
            
        }
        private Role(
            RoleId id,
            string name,
            CustomDateTime createdDateTime,
            UserId createdBy,
            CustomDateTime? modifiedDateTime,
            UserId? modifiedBy,
            CustomDateTime? deletedDateTime,
            UserId? deletedBy) 
        {
            Id = id;
            Name = name;
            CreatedTime = createdDateTime;
            CreatedByUserForeignKey = createdBy;
            LastModifiedTime = modifiedDateTime;
            LastModifiedByUserForeignKey = modifiedBy;
            DeletedTime = deletedDateTime;
            DeletedByUserForeignKey = deletedBy;
        }
        public static Role Create(
            RoleId id,
            string name,
            CustomDateTime createdDateTime,
            UserId createdBy,
            CustomDateTime? modifiedDateTime,
            UserId? modifiedBy,
            CustomDateTime? deletedDateTime,
            UserId? deletedBy)
        {
            return new Role(
                id,
                name,
                createdDateTime,
                createdBy,
                modifiedDateTime,
                modifiedBy,
                deletedDateTime,
                deletedBy);
        }
    }
}
