using MediatR;

namespace Shared.Primitives
{
    public record DomainEvent(Entity entity) : INotification
    {
    }
}
