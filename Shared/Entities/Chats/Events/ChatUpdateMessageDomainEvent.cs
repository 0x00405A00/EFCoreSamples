using Shared.Entities.Users;
using Shared.Primitives;

namespace Shared.Entities.Chats.Events
{
    public record ChatUpdateMessageDomainEvent(Chat e, EUser execUser, EUser messageOwner, Message message) : DomainEvent(e)
    {
    }
}
