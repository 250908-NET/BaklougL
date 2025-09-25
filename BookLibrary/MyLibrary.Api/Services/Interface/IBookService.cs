using MyLibrary.Api.Models;
using MyLibrary.Api.Data;

namespace MyLibrary.Api.Services;

public interface IBookService
{
    public Task<List<Book>> GetAllBooksAsync();
    public Task<Book?> GetBookByIdAsync(int id);
    public Task<Book> AddBookAsync(Book book);
    public Task<Book?> UpdateBookAsync(int id, Book updatedBook);
    public Task<bool> DeleteBookAsync(int id);

    public Task<List<Book>> GetBooksByUserIdAsync(int userId);
}