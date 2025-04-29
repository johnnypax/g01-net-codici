var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<Product> products = new()
{
    new Product { Id = 1, Name = "Laptop", Price = 1200.99M },
    new Product { Id = 2, Name = "Mouse", Price = 25.50M },
    new Product { Id = 3, Name = "Keyboard", Price = 45.00M }
};

app.MapGet("/", () => "It works!");

//Endpoint custom
app.MapGet("/products", () => Results.Ok(products));
app.MapGet("/products/{id}", (int id) => {
    var prod = products.FirstOrDefault(p => p.Id == id);
    return prod is not null ? Results.Ok(prod) : Results.NotFound();
});

app.MapPost("/products", (Product prod) => {
    prod.Id = products.Count + 1;
    products.Add(prod);
    return Results.Created($"/products/{prod.Id}", prod);
});

app.Run();

public partial class Program {};

record Product{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
}