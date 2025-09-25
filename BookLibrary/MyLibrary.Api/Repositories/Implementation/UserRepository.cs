using MyLibrary.Api.Models;
using MyLibrary.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace MyLibrary.Api.Repositories;


public class UserRepository : IUserRepository
{
    private readonly MyLibraryDbContext _dbContext;

    public UserRepository(MyLibraryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<User> AddUserAsync(User user)
    {
        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync();
        return user;
    }

    public async Task<User?> GetUserByIdAsync(int id)
    {
        return await _dbContext.Users.FindAsync(id);
    }

    public async Task<List<User>> GetAllUsersAsync()
    {
        return await _dbContext.Users.ToListAsync();
    }


    public async Task<List<Book>> GetBooksByUserIdAsync(int userId)
    {
        return await _dbContext.Books
            .Where(b => b.Id == userId)
            .ToListAsync();
    }
   
}