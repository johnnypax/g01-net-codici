var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

#region Middleware


app.Use(async (context, next) =>
{
    var logger = app.Logger;

    logger.LogWarning("Middleware 1: Prima del delegato");
    await next.Invoke();
    logger.LogWarning("Middleware 1: Dopo del delegato");
});

app.Use(async (context, next) =>
{
    var logger = app.Logger;

    logger.LogWarning("Middleware 2: Prima del delegato");
    await next.Invoke();
    logger.LogWarning("Middleware 2: Dopo del delegato");
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