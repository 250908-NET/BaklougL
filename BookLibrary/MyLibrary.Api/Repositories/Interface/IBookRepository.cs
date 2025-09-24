using MyLibrary.Api.Models;


namespace MyLibrary.Api.Repositories;


public interface IBookRepository
{
    public Task<List<Book>> GetAllBooksAsync();
    public Task<Book?> GetBookByIdAsync(int id);
    public Task<Book> AddBookAsync(Book book);
    public Task<Book?> UpdateBookAsync(int id, Book updatedBook);
    public Task<bool> DeleteBookAsync(int id);
    
}