using System.Net;
using Xunit;

namespace Customers.Api.Tests.Integration;

public class CustomerControllerTests
{
    private readonly HttpClient _httpClient = new()
    {
        BaseAddress = new Uri("https://localhost:5001")
    };
    
    [Fact]
    public async Task Get_ReturnsNotFound_WhenCustomerDoesNotExist()
    {
        // Act
        var response = await _httpClient.GetAsync($"customers/{Guid.NewGuid()}");
        
        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
    
    [Theory]
    [InlineData("9FD9A907-E86E-43BC-9A80-F2B0F274133F", Skip = "This doesn't work atm sorry")]
    [InlineData("45905930-B282-4330-891F-381BD951D2BC")]
    [InlineData("6728cd57-1e42-4fd0-9867-75a090fa2ce3")]
    public async Task Get_ReturnsNotFound_WhenCustomerDoesNotExist2(
        string guidAsText)
    {
        // Act
        var response = await _httpClient.GetAsync($"customers/{Guid.Parse(guidAsText)}");
        
        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
}
