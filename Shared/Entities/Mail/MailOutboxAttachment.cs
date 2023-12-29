﻿using Shared.Primitives;
using Shared.ValueObjects.Ids;

namespace Shared.Entities.Mail
{
    public sealed partial class MailOutboxAttachment : Entity<MailOutboxAttachmentId>
    {
        public MailOutboxId MailOutboxForeignKey { get; private set; }
        public string Filename { get; private set; }
        public string AttachmentPath { get; private set; }
        public int Order { get; private set; }
        public string AttachmentSha1 { get; private set; }
        public string MimeMediaType { get; private set; }
        public string MimeMediaSubType { get; private set; }
        public bool? IsEmbededInHtml { get; private set; }
        public string MimeCid { get; private set; }

        private MailOutboxAttachment() : base()
        {

        }
        private MailOutboxAttachment(
            MailOutboxAttachmentId mailOutboxRecipientId,
            MailOutboxId mailOutboxId,
            string fileName,
            string attachmentPath,
            int order,
            string attachmentSha1,
            string mimeMediaType,
            string mimeMediaSubType,
            bool isEmbededInHtml,
            string mimeCid,
            CustomDateTime createdDateTime,
            CustomDateTime? modifiedDateTime,
            CustomDateTime? deletedDateTime)
        {
            Id = mailOutboxRecipientId;
            MailOutboxForeignKey = mailOutboxId;
            Filename = fileName;
            AttachmentPath = attachmentPath;
            Order = order;
            AttachmentSha1 = attachmentSha1;
            MimeMediaType = mimeMediaType;
            MimeMediaSubType = mimeMediaSubType;
            IsEmbededInHtml = isEmbededInHtml;
            MimeCid = mimeCid;
            CreatedTime = createdDateTime;
            LastModifiedTime = modifiedDateTime;
            DeletedTime = deletedDateTime;
        }
        public static MailOutboxAttachment Create(
            MailOutboxAttachmentId mailOutboxRecipientId,
            MailOutboxId mailOutboxId,
            string fileName,
            string attachmentPath,
            int order,
            string attachmentSha1,
            string mimeMediaType,
            string mimeMediaSubType,
            bool isEmbededInHtml,
            string mimeCid,
            CustomDateTime createdDateTime,
            CustomDateTime? modifiedDateTime,
            CustomDateTime? deletedDateTime)
        {
            return new MailOutboxAttachment(
                mailOutboxRecipientId,
                mailOutboxId,
                fileName,
                attachmentPath,
                order,
                attachmentSha1,
                mimeMediaType,
                mimeMediaSubType,
                isEmbededInHtml,
                mimeCid,
                createdDateTime,
                modifiedDateTime,
                deletedDateTime);
        }
    }
    public sealed partial class MailOutboxAttachment
    {
        public MailOutbox Mail { get; set; }
    }
}