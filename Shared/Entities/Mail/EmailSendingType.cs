using Shared.Primitives;
using Shared.ValueObjects.Ids;

namespace Shared.Entities.Mail
{
    public sealed partial class EmailSendingType : Entity<EmailTypeId>
    {
        public string Name { get; private set; }

        private EmailSendingType() : base()
        {

        }
        private EmailSendingType(EmailTypeId emailTypeId, string name,
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
        public static EmailSendingType Create(
            EmailTypeId emailTypeId,
            string name,
            CustomDateTime createdDateTime,
            CustomDateTime? modifiedDateTime,
            CustomDateTime? deletedDateTime)
        {
            return new EmailSendingType(
                emailTypeId,
                name,
                createdDateTime,
                modifiedDateTime,
                deletedDateTime);
        }
    }
    public sealed partial class EmailSendingType
    {
        public ICollection<MailOutboxRecipient> MailOutboxRecipients { get; }
    }
}
