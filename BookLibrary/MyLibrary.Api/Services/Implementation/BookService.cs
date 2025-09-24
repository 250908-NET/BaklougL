using MyLibrary.Api.Models;
using MyLibrary.Api.Data;

namespace MyLibrary.Services;

public class BookService : IBookService
{

    private readonly IBookRepository _bookRepository;
    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    Task<List<Book>> GetAllBooksAsync() => _bookRepository.GetAllBooksAsync();  

    Task<Book?> GetBookByIdAsync(int id) => _bookRepository.GetBookByIdAsync(id);

    Task<Book> AddBookAsync(Book book)
    {
        await _bookRepository.AddBookAsync(book);
        await _bookRepository.SaveChangesAsync();
    }
    Task<Book?> UpdateBookAsync(int id, Book updatedBook) => _bookRepository.UpdateBookAsync(id, updatedBook);
    Task<bool> DeleteBookAsync(int id) => _bookRepository.DeleteBookAsync(id);
   
}