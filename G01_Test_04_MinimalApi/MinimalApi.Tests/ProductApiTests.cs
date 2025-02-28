using FluentAssertions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MinimalApi.Tests
{
    public class ProductApiTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _httpClient;

        public ProductApiTests(WebApplicationFactory<Program> factory)
        {
            _httpClient = factory.CreateClient();
        }

        [Fact]
        public async Task GetAllProducts_ShouldReturnList()
        {
            //Arrange

            //Act
            var response = await _httpClient.GetAsync("/products");

            //Assert
            //response.EnsureSuccessStatusCode();

            //var content = await response.Content.ReadAsStringAsync();
            //Assert.Contains("Laptop Gaming", content);
            //Assert.Contains("RAM 512MB", content);

            //Fluent
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var content = await response.Content.ReadAsStringAsync();
            content.Should().Contain("Laptop Gaming").And.Contain("RAM 512MB");
        }

        [Fact]
        public async Task PostProduct_ShouldReturnObject()
        {
            //Arrange
            var newProd = new { name = "Hard Disk", description = "Very Hard", price = 50 };
            var jsonBody = JsonSerializer.Serialize(newProd);
            var body = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            //Act
            var response = await _httpClient.PostAsync("/products", body);

            //Assert
            //response.EnsureSuccessStatusCode();
            //var responseBody = await response.Content.ReadAsStringAsync();
            //Assert.Contains("Hard Disk", responseBody);

            //Fluent
            response.StatusCode.Should().Be(HttpStatusCode.Created);
            var responseBody = await response.Content.ReadAsStringAsync();
            responseBody.Should().Contain("Hard Disk");
        }
    }
}
