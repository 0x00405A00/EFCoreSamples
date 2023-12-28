using Shared.Primitives;

namespace Shared.Entities.Chats.Events
{
    public record ChatCreatedDomainEvent(Chat e) : DomainEvent(e)
    {
    }
}
