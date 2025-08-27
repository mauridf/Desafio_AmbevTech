using Xunit;
using FluentAssertions;
using Desafio.Domain.Entities;
using System;

public class SaleItemTests
{
    [Theory]
    [InlineData(1, 0)]
    [InlineData(3, 0)]
    [InlineData(4, 0.10)]
    [InlineData(9, 0.10)]
    [InlineData(10, 0.20)]
    [InlineData(20, 0.20)]
    public void CalculateDiscountPercent_ShouldApplyCorrectly(int qty, double expectedPercent)
    {
        var productId = Guid.NewGuid();
        var unit = 100m;
        var item = new SaleItem(productId, qty, unit);

        item.Total.Should().Be(unit * qty * (1m - (decimal)expectedPercent));
    }

    [Fact]
    public void QuantityGreaterThan20_ShouldThrowDomainException()
    {
        var productId = Guid.NewGuid();
        Action act = () => new SaleItem(productId, 21, 10m);

        act.Should().Throw<DomainException>();
    }
}
