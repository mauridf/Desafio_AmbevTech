using Xunit;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Desafio.Data;
using Desafio.Data.Repositories;
using Desafio.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Desafio.Tests.Unit
{
    public class SaleRepositoryTests
    {
        private DefaultContext GetInMemoryContext()
        {
            var options = new DbContextOptionsBuilder<DefaultContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            return new DefaultContext(options);
        }

        [Fact]
        public async Task Should_Add_And_Get_Sale()
        {
            using var context = GetInMemoryContext();
            var repo = new SaleRepository(context);

            var sale = new Sale("V003", Guid.NewGuid(), Guid.NewGuid());
            sale.AddItem(Guid.NewGuid(), 2, 50);
            await repo.AddAsync(sale);

            var saved = await repo.GetByIdAsync(sale.Id);
            saved.Should().NotBeNull();
            saved.Items.Count.Should().Be(1);
        }
    }
}
