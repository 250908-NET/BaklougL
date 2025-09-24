using MyLibrary.Api.Models;
using Microsoft.EntityFrameworkCore;



namespace MyLibrary.Api.Repository;

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

    public async Task<IEnumerable<Book>> GetAllBooksAsync()
    {
        return await _dbContext.Books.ToListAsync();
    }

    public async Task UpdateBookAsync(Book book)
    {
        _dbContext.Books.Update(book);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteBookAsync(int id)
    {
        var book = await _dbContext.Books.FindAsync(id);
        if (book != null)
        {
            _dbContext.Books.Remove(book);
            await _dbContext.SaveChangesAsync();
        }
    }
}