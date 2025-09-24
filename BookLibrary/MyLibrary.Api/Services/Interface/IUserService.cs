using MyLibrary.Api.Models;
using MyLibrary.Api.Data;

namespace MyLibrary.Api.Services;

public interface IUserService
{ Task<List<User>> GetAllUsersAsync();
    public Task<User?> GetUserByIdAsync(int id);
    public Task<User> AddUserAsync(User user);
    
    
}