using MyLibrary.Api.Models;
using MyLibrary.Api.Data;

namespace MyLibrary.Services;

public class UserService : IUserService
{

    private readonly IUserRepository _userRepository;
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    Task<List<User>> GetAllUsersAsync() => _userRepository.GetAllUsersAsync();  

    Task<User?> GetUserByIdAsync(int id) => _userRepository.GetUserByIdAsync(id);

    async Task<User> AddUserAsync(User user)
    {
        await _userRepository.AddUserAsync(user);
        await _userRepository.SaveChangesAsync();
        return user;
    }
    Task<User?> UpdateUserAsync(int id, User updatedUser) => _userRepository.UpdateUserAsync(id, updatedUser);
    Task<bool> DeleteUserAsync(int id) => _userRepository.DeleteUserAsync(id);
   
}

