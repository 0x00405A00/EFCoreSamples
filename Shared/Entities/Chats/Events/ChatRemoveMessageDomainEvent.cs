using Shared.Entities.Users;
using Shared.Primitives;

namespace Shared.Entities.Chats.Events
{
    public record ChatRemoveMessageDomainEvent(Chat e, User execUser, User messageOwner, Message message) : DomainEvent(e)
    {
    }
}
