using Moq;
using MyLibrary.Api.Models;
using MyLibrary.Api.Services;
using MyLibrary.Api.Repositories;

namespace MyLibrary.Api.Tests.Services
{
    public class BookServiceTests
    {
        private readonly Mock<IBookRepository> _bookRepositoryMock;
        private readonly BookService _bookService;

        public BookServiceTests()
        {
            _bookRepositoryMock = new Mock<IBookRepository>();
            _bookService = new BookService(_bookRepositoryMock.Object);
        }

        [Fact]
        public async Task GetAllBooksAsync_ReturnsBooks()
        {
            // Arrange
            var books = new List<Book> { new Book { Id = 1, Title = "Test", Author = "Author", Genre = "Genre", PublishedYear = 2020 } };
            _bookRepositoryMock.Setup(r => r.GetAllBooksAsync()).ReturnsAsync(books);

            // Act
            var result = await _bookService.GetAllBooksAsync();

            // Assert
            Assert.Equal(books, result);
        }

        [Fact]
        public async Task SearchBooksByTitleAsync_ReturnsMatchingBooks()
        {
            // Arrange
            var title = "Test";
            var books = new List<Book> { new Book { Id = 1, Title = title, Author = "Author", Genre = "Genre", PublishedYear = 2020 } };
            _bookRepositoryMock.Setup(r => r.SearchBooksByTitleAsync(title)).ReturnsAsync(books);

            // Act
            var result = await _bookService.SearchBooksByTitleAsync(title);

            // Assert
            Assert.Equal(books, result);
        }

        [Fact]
        public async Task GetBooksByUserIdAsync_ReturnsUserBooks()
        {
            // Arrange
            int userId = 42;
            var books = new List<Book> { new Book { Id = 1, Title = "Test", Author = "Author", Genre = "Genre", PublishedYear = 2020 } };
            _bookRepositoryMock.Setup(r => r.GetBooksByUserIdAsync(userId)).ReturnsAsync(books);

            // Act
            var result = await _bookService.GetBooksByUserIdAsync(userId);

            // Assert
            Assert.Equal(books, result);
        }

        [Fact]
        public async Task DeleteBookAsync_ReturnsTrue_WhenBookDeleted()
        {
            // Arrange
            int bookId = 1;
            _bookRepositoryMock.Setup(r => r.DeleteBookAsync(bookId)).ReturnsAsync(true);

            // Act
            var result = await _bookService.DeleteBookAsync(bookId);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task AddBookAsync_ReturnsNull_WhenBookIsNull()
        {
            // Act
            var result = await _bookService.AddBookAsync(null);

            // Assert
            Assert.Null(result);
            _bookRepositoryMock.Verify(r => r.AddBookAsync(It.IsAny<Book>()), Times.Never);
        }

        [Fact]
        public async Task AddBookAsync_ReturnsBook_WhenBookIsValid()
        {
            // Arrange
            var book = new Book { Id = 1, Title = "Test", Author = "Author", Genre = "Genre", PublishedYear = 2020 };
            _bookRepositoryMock.Setup(r => r.AddBookAsync(book)).ReturnsAsync(book);

            // Act
            var result = await _bookService.AddBookAsync(book);

            // Assert
            Assert.Equal(book, result);
            _bookRepositoryMock.Verify(r => r.AddBookAsync(book), Times.Once);
        }
    }
}