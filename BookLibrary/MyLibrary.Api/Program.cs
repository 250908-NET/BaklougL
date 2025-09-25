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

builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IUserService, UserService>();


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


app.MapPost("/books", async (Book book, IBookService bookService) =>
{
    var createdBook = await bookService.AddBookAsync(book);
    return Results.Created($"/books/{createdBook.Id}", createdBook);
});

app.MapGet("/books", async (IBookService bookService) =>
{
    return Results.Ok(await bookService.GetAllBooksAsync());
});

app.MapGet("/books/{id}", async (int id, IBookService bookService) =>
{
    var book = await bookService.GetBookByIdAsync(id);
    return book is not null ? Results.Ok(book) : Results.NotFound();
});


// GET /users/{id}/books
app.MapGet("/users/{id}/books", async (int id, IUserService userService) =>
{
    var books = await userService.GetBooksByUserIdAsync(id);
    return Results.Ok(books);
});

app.Run();

