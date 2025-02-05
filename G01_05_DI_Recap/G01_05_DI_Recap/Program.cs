//Bootstrapping

using G01_05_DI_Recap;
using G01_05_DI_Recap.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((context, config) =>
    {
        config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
    })
    .ConfigureServices((context, services) =>
    {
#if DEBUG
        //var credenziali = context.Configuration.GetConnectionString("TestConnection");
        var credenziali = "Server=BOOK-N57JVKH6HJ\\SQLEXPRESS;Database=g01_03_CF_Libreria;User Id=academy;Password=academy!;MultipleActiveResultSets=true;Encrypt=false;TrustServerCertificate=false";
#else
        var credenziali = context.Configuration.GetConnectionString("ProdConnection");
#endif

        services.AddDbContext<LibreriaContex>(options => options.UseSqlServer(credenziali));
        services.AddTransient<App>();
    });

var app = builder.Build();

using var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetRequiredService<LibreriaContex>();
dbContext.Database.EnsureCreated();


await app.Services.GetRequiredService<App>().RunAsync();

