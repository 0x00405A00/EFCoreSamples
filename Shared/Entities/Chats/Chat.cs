using Shared.Entities.Users;
using Shared.Primitives;
using Shared.ValueObjects.Ids;

namespace Shared.Entities.Chats
{
    public sealed partial class Chat : AuditableEntity<ChatId>
    {
        public string Name { get; private set; }
        public string? Description { get; private set; }

        public string? PicturePath { get; private set; }
        public string? PictureFileExtension { get; private set; }

        private Chat():base() 
        {
            
        }

        private Chat(
            ChatId chatId,
            string name,
            string description,
            string picturePath,
            string pictureFileExtension,
            CustomDateTime createdDateTime,
            UserId createdBy,
            CustomDateTime? modifiedDateTime,
            UserId? modifiedBy,
            CustomDateTime? deletedDateTime,
            UserId? deletedBy)
        {
            Id = chatId;
            Name = name;
            Description = description;
            PicturePath = picturePath;
            PictureFileExtension = pictureFileExtension;
            CreatedTime = createdDateTime;
            CreatedByUserForeignKey = createdBy;
            LastModifiedTime = modifiedDateTime;
            LastModifiedByUserForeignKey = modifiedBy;
            DeletedTime = deletedDateTime;
            DeletedByUserForeignKey = deletedBy;
        }

        public static Chat Create(
            ChatId chatId,
            string name,
            string description,
            string picturePath,
            string pictureFileExtension,
            CustomDateTime createdDateTime,
            UserId createdBy,
            CustomDateTime? modifiedDateTime,
            UserId? modifiedBy,
            CustomDateTime? deletedDateTime,
            UserId? deletedBy)
        {

            return new Chat(
                chatId,
                name,
                description,
                picturePath,
                pictureFileExtension,
                createdDateTime,
                createdBy,
                modifiedDateTime,
                modifiedBy,
                deletedDateTime,
                deletedBy);
        }
    }
    public sealed partial class Chat
    {
        public ICollection<ChatRelationToUser> ChatRelationToUsers { get; }
        public ICollection<Message> Messages { get; }
    }
}
