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

    public Task<Book?> GetBookByIdAsync(int id) => _bookRepository.GetBookByIdAsync(id);

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