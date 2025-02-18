var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseHttpsRedirection();

app.MapGet("/", () =>
{
    return "Ciao sono Giovanni Pace e la API sta funzionando.";
});

app.MapGet("/secondo", () => "Sono il secondo endpoint ;)");

app.Run();


