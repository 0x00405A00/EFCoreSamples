using Shared.Entities.Users;
using Shared.Primitives;

namespace Shared.Entities.Chats.Events
{
    public record ChatAppendMessageDomainEvent(Chat e, EUser messageOwner, Message message) : DomainEvent(e)
    {
    }
}
