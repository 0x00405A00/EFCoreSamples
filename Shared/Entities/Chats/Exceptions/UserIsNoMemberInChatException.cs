namespace Shared.Entities.Chats.Exceptions
{
    public class UserIsNoMemberInChatException : System.Exception
    {
        public UserIsNoMemberInChatException(string? message) : base(message)
        {
        }
    }
}
