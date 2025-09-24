using MyLibrary.Api.Models;
using MyLibrary.Api.Data;

namespace MyLibrary.Services;
public interface ILoanService
{
    Task<List<Loan>> GetAllLoansAsync();
    Task<Loan?> GetLoanByIdAsync(int id);
    Task<Loan> AddLoanAsync(Loan loan);
    Task<Loan?> UpdateLoanAsync(int id, Loan updatedLoan);
    Task<bool> DeleteLoanAsync(int id);
}