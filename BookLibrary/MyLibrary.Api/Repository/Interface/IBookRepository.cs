using MyLibrary.Api.Models;


namespace MyLibrary.Api.Repository;


public interface IBookRepository
{
    Task<List<Book>> GetAllBooksAsync();
    Task<Book?> GetBookByIdAsync(int id);
    Task AddBookAsync(Book book);
    Task<Book?> UpdateBookAsync(int id, Book updatedBook);
    Task<bool> DeleteBookAsync(int id);
    
}