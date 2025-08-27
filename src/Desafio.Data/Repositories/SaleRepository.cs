using Desafio.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Desafio.Data.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly DefaultContext _context;
        public SaleRepository(DefaultContext context) => _context = context;

        public async Task<Sale> GetByIdAsync(Guid id) =>
            await _context.Sales.Include(s => s.Items).FirstOrDefaultAsync(s => s.Id == id);

        public async Task<List<Sale>> GetAllAsync() =>
            await _context.Sales.Include(s => s.Items).ToListAsync();

        public async Task AddAsync(Sale sale)
        {
            await _context.Sales.AddAsync(sale);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Sale sale)
        {
            _context.Sales.Update(sale);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Sale sale)
        {
            _context.Sales.Remove(sale);
            await _context.SaveChangesAsync();
        }
    }
}
