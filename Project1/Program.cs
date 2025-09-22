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

            builder.Services.AddOpenApi();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();
            builder.Host.UseSerilog();

            var app = builder.Build();


            if (!app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            app.MapGet("/", (ILogger<Program> logger) =>
            {
                logger.LogInformation("Hello, world!");
                return "Hello World!";
            });
            app.Run();
        }
    }
}