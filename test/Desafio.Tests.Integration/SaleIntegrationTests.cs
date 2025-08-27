using Xunit;
using Testcontainers.MsSql;
using System.Threading.Tasks;
using FluentAssertions;

public class SaleIntegrationTests
{
    [Fact]
    public async Task Should_Connect_To_SQLServer_Container()
    {
        var container = new MsSqlBuilder().Build();
        await container.StartAsync();

        var connectionString = container.GetConnectionString();
        connectionString.Should().Contain("Server=");

        await container.StopAsync();
    }
}
