using Desafio.Domain.Entities;

namespace Desafio.Domain.Events
{
    public class SaleCreatedEvent : DomainEvent
    {
        public Sale Sale { get; }
        public override string EventName => "CompraCriada";

        public SaleCreatedEvent(Sale sale)
        {
            Sale = sale;
        }
    }

    public class SaleUpdatedEvent : DomainEvent
    {
        public Sale Sale { get; }
        public override string EventName => "CompraAlterada";

        public SaleUpdatedEvent(Sale sale)
        {
            Sale = sale;
        }
    }

    public class SaleCancelledEvent : DomainEvent
    {
        public Sale Sale { get; }
        public override string EventName => "CompraCancelada";

        public SaleCancelledEvent(Sale sale)
        {
            Sale = sale;
        }
    }

    public class SaleItemCancelledEvent : DomainEvent
    {
        public Guid ItemId { get; }
        public override string EventName => "ItemCancelado";

        public SaleItemCancelledEvent(Guid itemId)
        {
            ItemId = itemId;
        }
    }
}
