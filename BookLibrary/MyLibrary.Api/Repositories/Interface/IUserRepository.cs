using MyLibrary.Api.Models;


namespace MyLibrary.Api.Repositories;

public interface IUserRepository
{
    public Task<List<User>> GetAllUsersAsync();
    public Task<User?> GetUserByIdAsync(int id);
    public Task<User> AddUserAsync(User user);
    
    public Task<List<Book>> GetBooksByUserIdAsync(int userId);
    
}