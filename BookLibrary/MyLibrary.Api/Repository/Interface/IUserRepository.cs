using MyLibrary.Api.Models;


namespace MyLibrary.Api.Repository;

public interface IUserRepository
{
    Task<List<User>> GetAllUsersAsync();
    Task<User?> GetUserByIdAsync(int id);
    Task AddUserAsync(User user);
    Task<User?> UpdateUserAsync(int id, User updatedUser);
    Task<bool> DeleteUserAsync(int id);
}