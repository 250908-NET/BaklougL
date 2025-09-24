using MyLibrary.Api.Models;
using MyLibrary.Api.Data;

namespace MyLibrary.Services;

public interface IBookService
{
    Task<List<Book>> GetAllBooksAsync();
    Task<Book?> GetBookByIdAsync(int id);
    Task<Book> AddBookAsync(Book book);
    Task<Book?> UpdateBookAsync(int id, Book updatedBook);
    Task<bool> DeleteBookAsync(int id);
}