using Shared.Primitives;
using Shared.ValueObjects.Ids;

namespace Shared.Entities.Mail
{
    public sealed partial class MailOutboxRecipient : Entity<MailOutboxRecipientId>
    {
        public string Email { get; private set; }
        public MailOutboxId MailOutboxForeignKey { get; private set; }
        public EmailTypeId EmailSendingTypeForeignKey { get; private set; }

        private MailOutboxRecipient() : base()
        {

        }
        private MailOutboxRecipient(
            MailOutboxRecipientId mailOutboxRecipientId,
            MailOutboxId mailOutboxId,
            EmailTypeId emailTypeId,
            string email,
            CustomDateTime createdDateTime,
            CustomDateTime? modifiedDateTime,
            CustomDateTime? deletedDateTime)
        {
            Id = mailOutboxRecipientId;
            MailOutboxForeignKey = mailOutboxId;
            EmailSendingTypeForeignKey = emailTypeId;
            Email = email;
            CreatedTime = createdDateTime;
            LastModifiedTime = modifiedDateTime;
            DeletedTime = deletedDateTime;
        }
        public static MailOutboxRecipient Create(
            MailOutboxRecipientId mailOutboxRecipientId,
            MailOutboxId mailOutboxId,
            EmailTypeId emailTypeId,
            string email,
            CustomDateTime createdDateTime,
            CustomDateTime? modifiedDateTime,
            CustomDateTime? deletedDateTime)
        {
            return new MailOutboxRecipient(
                mailOutboxRecipientId,
                mailOutboxId,
                emailTypeId,
                email,
                createdDateTime,
                modifiedDateTime,
                deletedDateTime);
        }
    }
    public sealed partial class MailOutboxRecipient
    {
        public MailOutbox Mail { get; set; }
        public EmailSendingType SendingType { get; set; }
    }
}
