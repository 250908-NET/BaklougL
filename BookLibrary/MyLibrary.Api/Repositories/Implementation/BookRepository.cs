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




    public async Task<List<Book>> GetAllBooksAsync()
    {
        return await _dbContext.Books.ToListAsync();
    }
    public async Task<List<Book>> SearchBooksByTitleAsync(string title)
    {
        return await _dbContext.Books
            .Where(b => b.Title.Contains(title))
            .ToListAsync();
    }


    public async Task<List<Book>> GetBooksByUserIdAsync(int userId)
    {
        return await _dbContext.Books
            .Where(b => b.Id == userId)
            .ToListAsync();
    }








    public async Task<Book> AddBookAsync(Book book)
    {
        _dbContext.Books.Add(book);
        await _dbContext.SaveChangesAsync();
        return book;
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