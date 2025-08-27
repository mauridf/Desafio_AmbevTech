using System.Collections.Generic;
using System.Linq;

namespace Desafio.Domain.Entities
{
    public class Sale
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string SaleNumber { get; private set; }
        public DateTime Date { get; private set; } = DateTime.UtcNow;
        public Guid CustomerId { get; private set; }
        public Guid BranchId { get; private set; }
        public bool Cancelled { get; private set; } = false;
        private readonly List<SaleItem> _items = new();
        public IReadOnlyCollection<SaleItem> Items => _items.AsReadOnly();
        public decimal Total => _items.Sum(i => i.Total);

        public Sale(string saleNumber, Guid customerId, Guid branchId)
        {
            SaleNumber = saleNumber ?? throw new ArgumentNullException(nameof(saleNumber));
            CustomerId = customerId;
            BranchId = branchId;
        }

        public void AddItem(Guid productId, int quantity, decimal unitPrice)
        {
            var item = new SaleItem(productId, quantity, unitPrice);
            _items.Add(item);
        }

        public void Cancel()
        {
            Cancelled = true;
        }
    }
}
