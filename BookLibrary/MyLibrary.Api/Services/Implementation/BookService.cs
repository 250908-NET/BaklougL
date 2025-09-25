using MyLibrary.Api.Models;
using MyLibrary.Api.Repositories;

namespace MyLibrary.Api.Services;

public class BookService : IBookService
{

    private readonly IBookRepository _bookRepository;

    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }




    public Task<List<Book>> GetAllBooksAsync() => _bookRepository.GetAllBooksAsync();
    public Task<List<Book>> SearchBooksByTitleAsync(string title) => _bookRepository.SearchBooksByTitleAsync(title);

    public Task<List<Book>> GetBooksByUserIdAsync(int userId) => _bookRepository.GetBooksByUserIdAsync(userId);









    public async Task<Book> AddBookAsync(Book book)
    {
        if (book == null)
            return null;

        _bookRepository.AddBookAsync(book);
        return book;

    }
    public Task<Book?> UpdateBookAsync(int id, Book updatedBook) => _bookRepository.UpdateBookAsync(id, updatedBook);
    public Task<bool> DeleteBookAsync(int id) => _bookRepository.DeleteBookAsync(id);
    

   
}