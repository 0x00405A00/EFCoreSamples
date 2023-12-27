using Shared.Entities.Users;
using Shared.ValueObjects.Ids;

namespace Shared.Primitives
{
    public interface IAuditableEntity
    {
        EUser? CreatedByUser { get; set; }
        UserId? CreatedByUserForeignKey { get; set; }
        EUser? DeletedByUser { get; set; }
        UserId? DeletedByUserForeignKey { get; set; }
        EUser? LastModifiedByUser { get; set; }
        UserId? LastModifiedByUserForeignKey { get; set; }
    }
}