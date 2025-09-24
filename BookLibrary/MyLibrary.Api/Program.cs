using Microsoft.EntityFrameworkCore;
using MyLibrary.Api.Models;
using MyLibrary.Api.Data;
using MyLibrary.Api.Services;
using MyLibrary.Api.Repositories;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

string CS = File.ReadAllText("../connection_string.env");

builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<MyLibraryDbContext>(options => options.UseSqlServer(CS));

builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ILoanRepository, LoanRepository>();

builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ILoanService, LoanService>();


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


// app.MapGet("/books", async (IBookService Service) =>
// {
//     Results.Ok(await service.GetAllBooksAsync());
// });

app.MapGet("/books/{id}", async (int id, IBookService bookService) =>
{
    var book = await bookService.GetBookByIdAsync(id);
    return book is not null ? Results.Ok(book) : Results.NotFound();
});



app.Run();

