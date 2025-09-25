using MyLibrary.Api.Models;
using System.Collections.Generic;


namespace MyLibrary.Api.Repositories;

public interface ILoanRepository
{
    // Define methods for managing loans, e.g.:
    public Task<List<Loan>> GetLoansByUserIdAsync(int userId);

    public Task<Loan> AddLoanAsync(Loan loan);

    public Task<Loan?> UpdateReturnDateAsync(int loanId, DateTime returnDate);

}