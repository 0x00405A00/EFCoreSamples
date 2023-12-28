using Shared.Primitives;

namespace Shared.Entities.Chats.Events
{
    public record ChatUpdatedDomainEvent(Chat e) : DomainEvent(e)
    {
    }
}
