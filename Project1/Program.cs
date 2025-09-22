// See https://aka.ms/new-console-template for more information
using System;
using Serilog;


namespace Project1
{
    class Program
    {
        static void Main(string[] args)
        {


            var builder = WebApplication.CreateBuilder(args);

            Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();
            builder.Host.UseSerilog();

            var app = builder.Build();
            app.MapGet("/", (ILogger<Program> logger) =>
            {
                logger.LogInformation("Hello, world!");
                return "Hello World!";
            });
            app.Run();
        }
    }
}