using System.Collections.Generic;

namespace Desafio.Application.DTOs
{
    public class SaleDto
    {
        public Guid Id { get; set; }
        public string SaleNumber { get; set; }
        public DateTime Date { get; set; }
        public Guid CustomerId { get; set; }
        public Guid BranchId { get; set; }
        public bool Cancelled { get; set; }
        public decimal Total { get; set; }
        public List<SaleItemDto> Items { get; set; } = new();
    }
}
