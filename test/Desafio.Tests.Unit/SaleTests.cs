using Xunit;
using FluentAssertions;
using Desafio.Domain.Entities;
using System;

namespace Desafio.Tests.Unit
{
    public class SaleTests
    {
        [Fact]
        public void Should_Create_Sale_With_Items_And_Calculate_Total()
        {
            var sale = new Sale("V001", Guid.NewGuid(), Guid.NewGuid());
            sale.AddItem(Guid.NewGuid(), 5, 100); // 5 itens -> 10% desconto
            sale.Total.Should().Be(450); // 500 - 10%
        }

        [Fact]
        public void Should_Cancel_Sale()
        {
            var sale = new Sale("V002", Guid.NewGuid(), Guid.NewGuid());
            sale.Cancel();
            sale.Cancelled.Should().BeTrue();
        }
    }
}
