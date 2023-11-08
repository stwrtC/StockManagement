using StockManagementLibraries.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllersWithViews();
        builder.Services.AddScoped<IStockRepository<GPU>, GPURepository>();
        builder.Services.AddScoped<IStockRepository<Laptop>, LaptopRepository>();
        var app = builder.Build();

        app.UseStaticFiles();

        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        app.MapDefaultControllerRoute();

        app.Run();
    }
}