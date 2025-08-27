using Microsoft.AspNetCore.Mvc;
using Desafio.Data.Repositories;
using Desafio.Application.DTOs;
using Desafio.Application.Mappers;
using Desafio.Domain.Entities;
using Microsoft.AspNetCore.Authorization;

namespace Desafio.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class SalesController : ControllerBase
    {
        private readonly ISaleRepository _repository;

        public SalesController(ISaleRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<SaleDto>>> GetAll()
        {
            var sales = await _repository.GetAllAsync();
            return Ok(sales.Select(s => s.ToDTO()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SaleDto>> GetById(Guid id)
        {
            var sale = await _repository.GetByIdAsync(id);
            if (sale == null) return NotFound();
            return Ok(sale.ToDTO());
        }

        [HttpPost]
        public async Task<ActionResult<SaleDto>> Create([FromBody] SaleCreateDto dto)
        {
            var sale = new Sale(dto.SaleNumber, dto.CustomerId, dto.BranchId);
            foreach (var item in dto.Items)
            {
                sale.AddItem(item.ProductId, item.Quantity, item.UnitPrice);
            }

            await _repository.AddAsync(sale);
            return CreatedAtAction(nameof(GetById), new { id = sale.Id }, sale.ToDTO());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, [FromBody] SaleCreateDto dto)
        {
            var sale = await _repository.GetByIdAsync(id);
            if (sale == null) return NotFound();

            foreach (var item in dto.Items)
            {
                sale.AddItem(item.ProductId, item.Quantity, item.UnitPrice);
            }

            await _repository.UpdateAsync(sale);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Cancel(Guid id)
        {
            var sale = await _repository.GetByIdAsync(id);
            if (sale == null) return NotFound();

            sale.Cancel();
            await _repository.UpdateAsync(sale);
            return NoContent();
        }
    }
}
