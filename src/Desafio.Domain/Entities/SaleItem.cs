namespace Desafio.Domain.Entities
{
    public class SaleItem
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public Guid ProductId { get; private set; }
        public int Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }
        public decimal DiscountPercent { get; private set; } = 0m;
        public decimal Total => CalculateTotal();

        public SaleItem(Guid productId, int quantity, decimal unitPrice)
        {
            if (quantity <= 0) throw new ArgumentException("Quantidade deve ser maior que zero");
            if (unitPrice <= 0) throw new ArgumentException("UnitPrice deve ser maior que zero");

            ProductId = productId;
            Quantity = quantity;
            UnitPrice = unitPrice;
            DiscountPercent = CalculateDiscountPercent(quantity);
        }

        private decimal CalculateDiscountPercent(int quantity)
        {
            if (quantity > 20) throw new DomainException("Quantidade maior que o permitido (>20)");
            if (quantity >= 10) return 0.20m;
            if (quantity >= 4) return 0.10m;
            return 0m;
        }

        private decimal CalculateTotal()
        {
            var subtotal = UnitPrice * Quantity;
            var discount = subtotal * DiscountPercent;
            return subtotal - discount;
        }
    }

    public class DomainException : Exception
    {
        public DomainException(string message) : base(message) { }
    }
}
