using G01_Test_04_MinimalApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

List<Product> products = new List<Product>()
{
    new Product(){ Id = 1, Name = "Laptop Gaming", Description = "Blablabla", Price = 750 },
    new Product(){ Id = 2, Name = "RAM 512MB", Description = "High Performace", Price = 80 }
};

app.MapGet("/products", () => products);

app.MapGet("/products/{id}", (int id) =>
{
    var prod = products.FirstOrDefault(p => p.Id == id);
    return prod is not null ? Results.Ok(prod) : Results.NotFound();
});

app.MapPost("/products", (Product pro) =>
{
    pro.Id = products.Count + 1;
    products.Add(pro);
    return Results.Created($"/products/{pro.Id}", pro);
});

app.Run();

public partial class Program { };
