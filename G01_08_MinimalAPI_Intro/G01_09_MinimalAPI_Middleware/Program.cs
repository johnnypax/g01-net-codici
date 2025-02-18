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

#region Middleware personalizzati

app.Use(async (context, next) =>
{
    var logger = app.Logger;
    logger.LogWarning("Middleware 1: Prima della richiesta NEXT");
    await next.Invoke();
    logger.LogWarning("Middleware 1: Dopo della richiesta NEXT");
});

app.Use(async (context, next) =>
{
    var logger = app.Logger;
    logger.LogWarning("Middleware 2: Prima della richiesta NEXT");
    await next.Invoke();
    logger.LogWarning("Middleware 2: Dopo della richiesta NEXT");
});

#endregion

#region Endpoint personalizzati

app.MapGet("/", () =>
{
    var logger = app.Logger;
    logger.LogInformation("Invoke /");

    return "Ciao hai appena invocato / endpoint";
});

app.MapGet("/secondo", () =>
{
    var logger = app.Logger;
    logger.LogInformation("Invoke /secondo");

    return "Ciao hai appena invocato /secondo endpoint";
});


#endregion

app.Run();

