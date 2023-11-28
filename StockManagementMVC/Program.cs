using log4net.Config;
using Microsoft.AspNetCore.Http.Extensions;
using StockManagementLibraries.Logging;
using StockManagementLibraries.Models;
using StockManagementMVC.Controllers;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddLogging(loggingBuilder =>
        {
            loggingBuilder.SetMinimumLevel(LogLevel.Trace);
            loggingBuilder.AddLog4Net();
            XmlConfigurator.Configure(new FileInfo("C:\\dev\\StockManagement\\StockManagementMVC\\log4net.config"));
        });

        builder.Services.AddControllersWithViews().ConfigureApiBehaviorOptions(options =>
        {
            var builtInFactory = options.InvalidModelStateResponseFactory;

            options.InvalidModelStateResponseFactory = context =>
            {
                if (context.HttpContext.Request.GetDisplayUrl().Contains("gpus"))
                {
                    var logger = context.HttpContext.RequestServices.GetRequiredService<ILogger<GPUController>>();
                    logger.LogError($"{LogStrings.RequestFailed}{LogStrings.Http400}");
                }
                else if (context.HttpContext.Request.GetDisplayUrl().Contains("laptops"))
                {
                    var logger = context.HttpContext.RequestServices.GetRequiredService<ILogger<LaptopController>>();
                    logger.LogError($"{LogStrings.RequestFailed}{LogStrings.Http400}");
                }
                return builtInFactory(context);
            };
        });
        builder.Services.AddSingleton<IStockRepository<GPU>, JsonGPURepository>();
        builder.Services.AddSingleton<IStockRepository<Laptop>, JsonLaptopRepository>();
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