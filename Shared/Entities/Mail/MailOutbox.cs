using Shared.Primitives;
using Shared.ValueObjects.Ids;

namespace Shared.Entities.Mail
{
    public sealed partial class MailOutbox : Entity<MailOutboxId>
    {
        public string From { get; private set; }
        public string Subject { get; private set; }
        public string Body { get; private set; }
        public bool? IsBodyHtml { get; private set; }

        private MailOutbox() : base()
        {

        }
        private MailOutbox(
            MailOutboxId id,
            string from,
            string subject,
            string body,
            bool isBodyHtml,
            CustomDateTime createdDateTime,
            CustomDateTime? modifiedDateTime,
            CustomDateTime? deletedDateTime)
        {
            Id = id;
            From = from;
            Subject = subject;
            Body = body;
            IsBodyHtml = isBodyHtml;
            CreatedTime = createdDateTime;
            LastModifiedTime = modifiedDateTime;
            DeletedTime = deletedDateTime;
        }
        public static MailOutbox Create(
            MailOutboxId id,
            string from,
            string subject,
            string body,
            bool isBodyHtml,
            CustomDateTime createdDateTime,
            CustomDateTime? modifiedDateTime,
            CustomDateTime? deletedDateTime)
        {
            return new MailOutbox(
                id,
                from,
                subject,
                body,
                isBodyHtml,
                createdDateTime,
                modifiedDateTime,
                deletedDateTime);
        }
    }
    public sealed partial class MailOutbox
    {
        public ICollection<MailOutboxAttachment> Attachments { get; }
        public ICollection<MailOutboxRecipient> Recipients { get; }
    }
}
