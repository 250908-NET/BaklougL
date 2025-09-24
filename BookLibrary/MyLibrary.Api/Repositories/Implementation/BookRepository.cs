using MyLibrary.Api.Models;
using MyLibrary.Api.Data;
using Microsoft.EntityFrameworkCore;



namespace MyLibrary.Api.Repositories;

public class BookRepository : IBookRepository
{
    private readonly MyLibraryDbContext _dbContext;

    public BookRepository(MyLibraryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Book> AddBookAsync(Book book)
    {
        _dbContext.Books.Add(book);
        await _dbContext.SaveChangesAsync();
        return book;
    }

    public async Task<Book?> GetBookByIdAsync(int id)
    {
        return await _dbContext.Books.FindAsync(id);
    }

    public async Task<List<Book>> GetAllBooksAsync()
    {
        return await _dbContext.Books.ToListAsync();
    }

   public async Task<Book?> UpdateBookAsync(int id, Book updatedBook)
{
    var existingBook = await _dbContext.Books.FindAsync(id);
    if (existingBook == null)
        return null;

    existingBook.Title = updatedBook.Title;
    existingBook.Author = updatedBook.Author;
    existingBook.PublishedYear = updatedBook.PublishedYear;

    _dbContext.Books.Update(existingBook);
    await _dbContext.SaveChangesAsync();

    return existingBook;
}

    public async Task<bool> DeleteBookAsync(int id)
{
    var book = await _dbContext.Books.FindAsync(id);
    if (book == null)
        return false;

    _dbContext.Books.Remove(book);
    await _dbContext.SaveChangesAsync();
    return true;
}
    
}