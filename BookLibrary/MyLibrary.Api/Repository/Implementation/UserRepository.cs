using MyLibrary.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace MyLibrary.Api.Repository;


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

    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        return await _dbContext.Users.ToListAsync();
    }

    public async Task UpdateUserAsync(User user)
    {
        _dbContext.Users.Update(user);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteUserAsync(int id)
    {
        var user = await _dbContext.Users.FindAsync(id);
        if (user != null)
        {
            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();
        }
    }
}