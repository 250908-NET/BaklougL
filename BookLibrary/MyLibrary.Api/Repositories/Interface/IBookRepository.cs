using MyLibrary.Api.Models;


namespace MyLibrary.Api.Repositories;


public interface IBookRepository
{
    public Task<List<Book>> GetAllBooksAsync();
    public Task<List<Book>> SearchBooksByTitleAsync(string title);
    public Task<List<Book>> GetBooksByUserIdAsync(int userId);



    public Task<Book> AddBookAsync(Book book);
    public Task<bool> DeleteBookAsync(int id);
    

    



}