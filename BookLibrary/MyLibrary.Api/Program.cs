using Microsoft.EntityFrameworkCore;
using MyLibrary.Api.Models;
using MyLibrary.Api.Data;

using Serilog;

var builder = WebApplication.CreateBuilder(args);

string CS = File.ReadAllText("../connection_string.env");

builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<MyLibraryDbContext>(options => options.UseSqlServer(CS));
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ILoanRepository, LoanRepository>();



Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration).CreateLogger(); 
builder.Host.UseSerilog();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();


app.MapGet("/", () =>
{
    return "Hello World!";
});

app.Run();

