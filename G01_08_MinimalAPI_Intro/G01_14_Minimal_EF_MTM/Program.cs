using G01_14_Minimal_EF_MTM.Context;
using G01_14_Minimal_EF_MTM.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

#region Configurazione context
var connectionString = builder.Configuration.GetConnectionString("TestConnection");

builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlServer(connectionString));
#endregion

#region Configurazione serializzatore
builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;

    //options.SerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
    //options.SerializerOptions.MaxDepth = 3;
});
#endregion

var app = builder.Build();

//Riversa le migrazioni sul DB invocando lo scope per accedere al SP
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.Migrate();
}

app.UseHttpsRedirection();

app.MapGet("/", () => "Sto funzionando (forse...)");

app.MapGet("/prodotti", async (AppDbContext ctx) =>
{
    return await ctx.Prodottos
                        .Include(p => p.ProdottoCategorias)
                        .ThenInclude(pc => pc.CategoriaNav)
                        .ToListAsync();
});

app.MapGet("/prodotti/dto", async (AppDbContext ctx) =>
{
    return await ctx.Prodottos
                        .Include(p => p.ProdottoCategorias)
                        .ThenInclude(pc => pc.CategoriaNav)
                        .Select(p => new ProdottoDTO
                        {
                            Id = p.Id,
                            Nome = p.Nome,  
                            Prezzo = p.Prezzo,
                            Categorias = p.ProdottoCategorias.Select(pc => pc.CategoriaNav.Nome).ToList()
                        })
                        .ToListAsync();
});

app.MapPost("/prodotti/{pId:int}/categoria/{cId:int}", async (AppDbContext ctx, int pId, int cId) =>
{
    //Todo: Completare...
    return Results.Ok();
});

app.Run();

