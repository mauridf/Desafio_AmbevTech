namespace Desafio.Domain.Events
{
    public abstract class DomainEvent
    {
        public DateTime OccurredOn { get; protected set; } = DateTime.UtcNow;
        public abstract string EventName { get; }
    }
}
