using Shared.Primitives;

namespace Shared.Entities.Chats.Events
{
    public record ChatDeletedDomainEvent(Chat e) : DomainEvent(e)
    {
    }
}
