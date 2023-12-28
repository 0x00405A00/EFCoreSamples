using Shared.Entities.Users;
using Shared.Primitives;

namespace Shared.Entities.Chats.Events
{
    public record ChatRemoveMessageDomainEvent(Chat e, EUser execUser, EUser messageOwner, Message message) : DomainEvent(e)
    {
    }
}
