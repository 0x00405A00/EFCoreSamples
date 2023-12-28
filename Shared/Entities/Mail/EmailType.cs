using Shared.Primitives;
using Shared.ValueObjects.Ids;

namespace Shared.Entities.Mail
{
    public sealed class EmailType : Entity<EmailTypeId>
    {
        public string Name { get; private set; }

        private EmailType() : base()
        {

        }
        private EmailType(EmailTypeId emailTypeId, string name,
            CustomDateTime createdDateTime,
            CustomDateTime? modifiedDateTime,
            CustomDateTime? deletedDateTime)
        {
            Id= emailTypeId;    
            Name = name;
            CreatedTime = createdDateTime;
            LastModifiedTime = modifiedDateTime;
            DeletedTime = deletedDateTime;
        }
        public static EmailType Create(
            EmailTypeId emailTypeId,
            string name,
            CustomDateTime createdDateTime,
            CustomDateTime? modifiedDateTime,
            CustomDateTime? deletedDateTime)
        {
            return new EmailType(
                emailTypeId,
                name,
                createdDateTime,
                modifiedDateTime,
                deletedDateTime);
        }
    }
}
