using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

public class PublicApiTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public PublicApiTests(WebApplicationFactory<Program> factory){
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetAll_Products_ShouldReturnOk(){
        var response = await _client.GetAsync("/products");
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task GetById_ShouldReturnNotFound_ForInvalidId(){
        var response = await _client.GetAsync("/products/888");
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task Create_Product_ShouldReturnCreated(){
        var newProd = new { Name = "RAM", Price = 19.0 };
        var response = await _client.PostAsJsonAsync("/products", newProd);
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
    }


}