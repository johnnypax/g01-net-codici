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

#region Gestione Middlewares

app.Use(async (context, next) =>
{
    context.Response.Headers.Append("Giovanni-Header", "Ciao Giovanni");
    await next.Invoke();
});

app.Use(async (context, next) =>
{
    context.Response.Headers.Append("Pace-Header", "Ciao Pace");
    await next.Invoke();
});

#endregion

app.MapGet("/", () =>
{
    var logger = app.Logger;
    logger.LogInformation("Invocazione endpoint /");

    return "Ciao sono l'endpoint / invocato";
});

app.MapGet("/secondo", () =>
{
    var logger = app.Logger;
    logger.LogInformation("Invocazione endpoint /secondo");

    return "Ciao sono l'endpoint /secondo invocato";
});

app.Run();