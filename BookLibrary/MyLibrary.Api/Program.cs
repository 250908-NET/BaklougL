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






//user & admin can look for all available books
app.MapGet("/books", async (IBookService bookService) =>
{
    return Results.Ok(await bookService.GetAllBooksAsync());
});

//user & admin can look for aspecific book by name 
app.MapGet("/books/search", async (string title, IBookService bookService) =>
{
    var books = await bookService.SearchBooksByTitleAsync(title);
    return Results.Ok(books);
});


//user & admin can look up books being borrowed by a specific user    ///need to be tested 
app.MapGet("/users/{id}/loans", async (int id, ILoanService loanService) =>
{
    var loans = await loanService.GetLoansByUserIdAsync(id);
    return Results.Ok(loans);
});



//admin can add new books to the liberary
app.MapPost("/admin/books", async (Book book, IBookService bookService) =>
{
    var createdBook = await bookService.AddBookAsync(book);
    return Results.Created($"/books/{createdBook.Id}", createdBook);
});

//admin can add new books to the liberary
app.MapPost("/admin/users", async (User user, IUserService userService) =>
{
    var createdUser = await userService.AddUserAsync(user);
    return Results.Created($"/users/{createdUser.Id}", createdUser);
});

app.MapPost("/admin/loans", async (Loan loan, ILoanService loanService) =>
{
    var createdLoan = await loanService.AddLoanAsync(loan);
    return Results.Created($"/loans/{createdLoan.Id}", createdLoan);
});

// GET /users/{id}/books
// app.MapGet("/users/{id}/books", async (int id, IUserService userService) =>
// {
//     var books = await userService.GetBooksByUserIdAsync(id);
//     return Results.Ok(books);
// });

app.Run();




// app.MapGet("/books/{id}", async (int id, IBookService bookService) =>
// {
//     var book = await bookService.GetBookByIdAsync(id);
//     return book is not null ? Results.Ok(book) : Results.NotFound();
// });