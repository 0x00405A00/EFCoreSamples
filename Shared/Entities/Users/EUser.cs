using Shared.Entities.Auths;
using Shared.Entities.Chats;
using Shared.Entities.Roles;
using Shared.Primitives;
using Shared.ValueObjects.Ids;

namespace Shared.Entities.Users
{
    /// <summary>
    /// Base class for EUser, Navigations should be in 'public sealed partial class EUser'
    /// </summary>
    public sealed partial class EUser : AuditableEntity<UserId>
    {
        public UserId? CreatedByUserForeignKey { get; private set; }
        public UserId? LastModifiedByUserForeignKey { get; private set; }
        public UserId? DeletedByUserForeignKey { get; private set; }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        public UserTypeId UserTypeForeignKey { get; private set; }//<------- FK

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
            UserTypeForeignKey = userTypeId;
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

        public void SetName(string name) { Name = name; }
    }

    /// <summary>
    /// For Navigations
    /// </summary>
    public sealed partial class EUser
    {
        public UserType UserType { get; set; }//<---- Navigation Property must have the accessors get; set;

        public ICollection<UserHasRelationToRole> UserHasRelationToRoles { get; }

        public ICollection<ChatRelationToUser>? ChatRelationToUsers { get; }

        public ICollection<Message>? Messages { get; }
        public ICollection<Message>? CreatedMessages { get; }
        public ICollection<Message>? ModifiedMessages { get; }
        public ICollection<Message>? DeletedMessages { get; }

        /// <summary>
        /// Messages that are not received from user, when received (acknowledged) than the message should be removed from entity 'MessagesInOutbox'
        /// </summary>
        public ICollection<MessageOutbox>? MessagesInOutbox { get; }

        public ICollection<ChatRelationToUser>? CreatedChatRelationToUsers { get; }
        public ICollection<ChatRelationToUser>? ModifiedChatRelationToUsers { get; }
        public ICollection<ChatRelationToUser>? DeletedChatRelationToUsers { get; }

        public ICollection<Role> Roles { get; }

        public ICollection<UserHasRelationToFriend>? UserHasRelationToFriendsLeft { get; }
        public ICollection<UserHasRelationToFriend>? UserHasRelationToFriendsRight { get; }

        public ICollection<UserHasRelationToRole>? CreatedUserHasRelationToRoles { get; }
        public ICollection<UserHasRelationToRole>? ModifiedUserHasRelationToRoles { get; }
        public ICollection<UserHasRelationToRole>? DeletedUserHasRelationToRoles { get; }

        public ICollection<FriendshipRequest>? FriendshipRequestsWhereIamRequester { get; }
        public ICollection<FriendshipRequest>? FriendshipRequestsWhereIamTarget { get; }

        public ICollection<ChatInviteRequest>? ChatInvitesWhereIamRequester { get; }
        public ICollection<ChatInviteRequest>? ChatInvitesWhereIamTarget { get; }

        public ICollection<UserType>? CreatedUserTypes { get; }
        public ICollection<UserType>? ModifiedUserTypes { get; }
        public ICollection<UserType>? DeletedUserTypes { get; }

        public ICollection<Role>? CreatedRoles { get; }
        public ICollection<Role>? ModifiedRoles { get; }
        public ICollection<Role>? DeletedRoles { get; }

        public ICollection<Chat>? CreatedChats { get; }
        public ICollection<Chat>? ModifiedChats { get; }
        public ICollection<Chat>? DeletedChats { get; }

        public ICollection<EUser>? CreatedEUsers { get; }
        public ICollection<EUser>? ModifiedEUsers { get; }
        public ICollection<EUser>? DeletedEUsers { get; }

        public ICollection<Auth>? Auths { get; }
    }
}
