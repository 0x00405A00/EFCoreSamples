using Shared.Entities.Users;
using Shared.ValueObjects.Ids;

namespace Shared.Primitives
{
    public abstract class AuditableEntity<TEntityId> : Entity<TEntityId>, IAuditableEntity 
        where TEntityId : Identification
    {

        public UserId? CreatedByUserForeignKey { get; set; }
        public UserId? LastModifiedByUserForeignKey { get; set; }
        public UserId? DeletedByUserForeignKey { get; set; }
        public EUser? CreatedByUser { get; set; }
        public EUser? LastModifiedByUser { get; set; }
        public EUser? DeletedByUser { get; set; }
    }
}
