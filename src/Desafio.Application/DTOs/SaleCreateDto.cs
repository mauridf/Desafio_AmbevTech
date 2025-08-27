using System.Collections.Generic;

namespace Desafio.Application.DTOs
{
    public class SaleCreateDto
    {
        public string SaleNumber { get; set; }
        public Guid CustomerId { get; set; }
        public Guid BranchId { get; set; }
        public List<SaleItemCreateDto> Items { get; set; } = new();
    }

    public class SaleItemCreateDto
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
