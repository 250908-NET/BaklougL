using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using Xunit;
using MyLibrary.Api.Models;
using MyLibrary.Api.Services;
using MyLibrary.Api.Repositories;

namespace MyLibrary.Api.Tests.Services
{
    public class LoanServiceTests
    {
        private readonly Mock<ILoanRepository> _loanRepositoryMock;
        private readonly LoanService _loanService;

        public LoanServiceTests()
        {
            _loanRepositoryMock = new Mock<ILoanRepository>();
            _loanService = new LoanService(_loanRepositoryMock.Object);
        }

        [Fact]
        public async Task GetLoansByUserIdAsync_ReturnsLoans()
        {
            // Arrange
            int userId = 1;
            var loans = new List<Loan>
            {
                new Loan { Id = 1, UserId = userId, BookId = 2, LoanDate = DateTime.Today }
            };
            _loanRepositoryMock.Setup(r => r.GetLoansByUserIdAsync(userId)).ReturnsAsync(loans);

            // Act
            var result = await _loanService.GetLoansByUserIdAsync(userId);

            // Assert
            Assert.Equal(loans, result);
        }

        [Fact]
        public async Task AddLoanAsync_ReturnsLoan()
        {
            // Arrange
            var loan = new Loan { Id = 1, UserId = 2, BookId = 3, LoanDate = DateTime.Today };
            _loanRepositoryMock.Setup(r => r.AddLoanAsync(loan)).ReturnsAsync(loan);

            // Act
            var result = await _loanService.AddLoanAsync(loan);

            // Assert
            Assert.Equal(loan, result);
            _loanRepositoryMock.Verify(r => r.AddLoanAsync(loan), Times.Once);
        }

        [Fact]
        public async Task UpdateReturnDateAsync_ReturnsUpdatedLoan_WhenLoanExists()
        {
            // Arrange
            int loanId = 1;
            DateTime returnDate = DateTime.Today.AddDays(7);
            var updatedLoan = new Loan { Id = loanId, UserId = 2, BookId = 3, LoanDate = DateTime.Today, ReturnDate = returnDate };
            _loanRepositoryMock.Setup(r => r.UpdateReturnDateAsync(loanId, returnDate)).ReturnsAsync(updatedLoan);

            // Act
            var result = await _loanService.UpdateReturnDateAsync(loanId, returnDate);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(returnDate, result.ReturnDate);
            Assert.Equal(loanId, result.Id);
        }

        [Fact]
        public async Task UpdateReturnDateAsync_ReturnsNull_WhenLoanDoesNotExist()
        {
            // Arrange
            int loanId = 99;
            DateTime returnDate = DateTime.Today.AddDays(7);
            _loanRepositoryMock.Setup(r => r.UpdateReturnDateAsync(loanId, returnDate)).ReturnsAsync((Loan?)null);

            // Act
            var result = await _loanService.UpdateReturnDateAsync(loanId, returnDate);

            // Assert
            Assert.Null(result);
        }
    }
}