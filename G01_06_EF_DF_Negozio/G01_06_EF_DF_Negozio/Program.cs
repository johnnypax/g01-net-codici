using G01_06_EF_DF_Negozio.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

#region Configuro servizi personalizzati

var credenziali = builder.Configuration.GetConnectionString("TestConnection");

builder.Services.AddDbContext<G0104DfNegozioContext>(options => options.UseSqlServer(credenziali));

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
