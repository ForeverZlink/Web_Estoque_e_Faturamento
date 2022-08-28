using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Logging.ClearProviders();
builder.Logging.AddConsole();




// Configure the HTTP request pipeline.
if (builder.Environment.IsProduction())
{

    string MvcIndependentObjectsOfProductsContextCrendecialsDatabase = System.Environment.GetEnvironmentVariable("MvcIndependentObjectsOfProductsContext");
    builder.Configuration.AddJsonFile("appsettings.json").AddEnvironmentVariables($"MvcIndependentObjectsOfProductsContext:{MvcIndependentObjectsOfProductsContextCrendecialsDatabase}");
    string MvcProductContextCrendecialsDatabase = System.Environment.GetEnvironmentVariable("MvcProductContext");
    builder.Configuration.AddJsonFile("appsettings.json").AddEnvironmentVariables($"MvcProductContext:{MvcIndependentObjectsOfProductsContextCrendecialsDatabase}");

}


builder.Services.AddDbContext<MvcProductContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MvcProductContext")));


builder.Services.AddDbContext<MvcIndependentObjectsOfProductsContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MvcIndependentObjectsOfProductsContext"))
);

var app = builder.Build();


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseAuthorization();

app.MapRazorPages();
app.Run();
