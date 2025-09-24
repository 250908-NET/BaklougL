using MyLibrary.Api.Models;
using MyLibrary.Api.Data;

namespace MyLibrary.Services;

public interface IUserService
{ Task<List<User>> GetAllUsersAsync();
    Task<User?> GetUserByIdAsync(int id);
    Task<User> AddUserAsync(User user);
    Task<User?> UpdateUserAsync(int id, User updatedUser);
    Task<bool> DeleteUserAsync(int id);
}