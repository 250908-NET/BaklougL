using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using Xunit;
using MyLibrary.Api.Models;
using MyLibrary.Api.Services;
using MyLibrary.Api.Repositories;

namespace MyLibrary.Api.Tests.Services
{
    public class UserServiceTests
    {
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly UserService _userService;

        public UserServiceTests()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _userService = new UserService(_userRepositoryMock.Object);
        }

        [Fact]
        public async Task GetAllUsersAsync_ReturnsUsers()
        {
            // Arrange
            var users = new List<User> { new User { Id = 1, Name = "Alice" } };
            _userRepositoryMock.Setup(r => r.GetAllUsersAsync()).ReturnsAsync(users);

            // Act
            var result = await _userService.GetAllUsersAsync();

            // Assert
            Assert.Equal(users, result);
        }

        [Fact]
        public async Task GetUserByIdAsync_ReturnsUser_WhenExists()
        {
            // Arrange
            int userId = 1;
            var user = new User { Id = userId, Name = "Bob" };
            _userRepositoryMock.Setup(r => r.GetUserByIdAsync(userId)).ReturnsAsync(user);

            // Act
            var result = await _userService.GetUserByIdAsync(userId);

            // Assert
            Assert.Equal(user, result);
        }

        [Fact]
        public async Task GetUserByIdAsync_ReturnsNull_WhenNotExists()
        {
            // Arrange
            int userId = 99;
            _userRepositoryMock.Setup(r => r.GetUserByIdAsync(userId)).ReturnsAsync((User?)null);

            // Act
            var result = await _userService.GetUserByIdAsync(userId);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task AddUserAsync_ReturnsUser()
        {
            // Arrange
            var user = new User { Id = 2, Name = "Charlie" };
            _userRepositoryMock.Setup(r => r.AddUserAsync(user)).ReturnsAsync(user);

            // Act
            var result = await _userService.AddUserAsync(user);

            // Assert
            Assert.Equal(user, result);
            _userRepositoryMock.Verify(r => r.AddUserAsync(user), Times.Once);
        }

        [Fact]
        public async Task GetBooksByUserIdAsync_ReturnsBooks()
        {
            // Arrange
            int userId = 1;
            var books = new List<Book> { new Book { Id = 1, Title = "Book1", Author = "Author1", Genre = "Genre1", PublishedYear = 2020 } };
            _userRepositoryMock.Setup(r => r.GetBooksByUserIdAsync(userId)).ReturnsAsync(books);

            // Act
            var result = await _userService.GetBooksByUserIdAsync(userId);

            // Assert
            Assert.Equal(books, result);
        }
    }
}