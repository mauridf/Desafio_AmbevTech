using Desafio.Domain.Entities;

namespace Desafio.Domain.Events
{
    public class SaleItemAddedEvent : DomainEvent
    {
        public Sale Sale { get; }
        public SaleItem Item { get; }
        public override string EventName => "ItemAdicionado";

        public SaleItemAddedEvent(Sale sale, SaleItem item)
        {
            Sale = sale;
            Item = item;
        }
    }
}
