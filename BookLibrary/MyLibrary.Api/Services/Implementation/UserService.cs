using MyLibrary.Api.Models;
using MyLibrary.Api.Repositories;

namespace MyLibrary.Api.Services;

public class UserService : IUserService
{

    private readonly IUserRepository _userRepository;
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public Task<List<User>> GetAllUsersAsync() => _userRepository.GetAllUsersAsync();

    public Task<User?> GetUserByIdAsync(int id) => _userRepository.GetUserByIdAsync(id);

    public async Task<User> AddUserAsync(User user)
    {

        await _userRepository.AddUserAsync(user);
        return user;
    }

    public Task<List<Book>> GetBooksByUserIdAsync(int Id) => _userRepository.GetBooksByUserIdAsync(Id);
    
    
}
