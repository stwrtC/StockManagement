using log4net;
using log4net.Config;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using StockManagementLibraries.Models;
using System.Reflection;
using Microsoft.Extensions.Logging.Log4Net.AspNetCore.Extensions;
using StockManagement.API.Controllers;
using StockManagementLibraries.Logging;
using Microsoft.AspNetCore.Http.Extensions;

internal class Program
{
    
    private static void Main(string[] args)
    {
        
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddLogging(loggingBuilder =>
        {
            loggingBuilder.SetMinimumLevel(LogLevel.Trace);
            loggingBuilder.AddLog4Net();
            XmlConfigurator.Configure(new FileInfo("log4net.config"));
        });
        // Add services to the container.

        builder.Services.AddControllers().ConfigureApiBehaviorOptions(options =>
        {
            var builtInFactory = options.InvalidModelStateResponseFactory;

            options.InvalidModelStateResponseFactory = context =>
            {
                if (context.HttpContext.Request.GetDisplayUrl().Contains("gpus"))
                {
                    var logger = context.HttpContext.RequestServices.GetRequiredService<ILogger<GPUController>>();
                    logger.LogError($"{LogStrings.RequestFailed}{LogStrings.Http400}");
                }
                else if(context.HttpContext.Request.GetDisplayUrl().Contains("laptops"))
                {
                    var logger = context.HttpContext.RequestServices.GetRequiredService<ILogger<LaptopController>>();
                    logger.LogError($"{LogStrings.RequestFailed}{LogStrings.Http400}");
                }
                return builtInFactory(context);
            };
        }).AddNewtonsoftJson()
          .AddXmlDataContractSerializerFormatters();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddSingleton<IStockRepository<GPU>, GPURepository>();
        builder.Services.AddSingleton<IStockRepository<Laptop>, LaptopRepository>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        app.Run();
    }
}