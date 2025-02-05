using G01_04_Dependency_Injection;
using G01_04_Dependency_Injection.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        var credenziali = "";

        services.AddDbContext<LibreriaContext>(options => options.UseSqlServer(credenziali));

        services.AddTransient<App>();
    });

var app = builder.Build();

await app.Services.GetRequiredService<App>().RunAsync();