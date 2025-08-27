using Desafio.Domain.Entities;
using Desafio.Application.DTOs;

namespace Desafio.Application.Mappers
{
    public static class SaleMapper
    {
        public static SaleDto ToDTO(this Sale sale)
        {
            return new SaleDto
            {
                Id = sale.Id,
                SaleNumber = sale.SaleNumber,
                Date = sale.Date,
                CustomerId = sale.CustomerId,
                BranchId = sale.BranchId,
                Cancelled = sale.Cancelled,
                Total = sale.Total,
                Items = sale.Items.Select(i => new SaleItemDto
                {
                    ProductId = i.ProductId,
                    Quantity = i.Quantity,
                    UnitPrice = i.UnitPrice,
                    DiscountPercent = i.DiscountPercent,
                    Total = i.Total
                }).ToList()
            };
        }
    }
}
