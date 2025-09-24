using MyLibrary.Api.Models;


namespace MyLibrary.Api.Repository;


public interface ILoanRepository
{
    Task<List<Loan>> GetAllLoansAsync();
    Task<Loan?> GetLoanByIdAsync(int id);
    Task AddLoanAsync(Loan loan);
    Task<Loan?> UpdateLoanAsync(int id, Loan updatedLoan);
    Task<bool> DeleteLoanAsync(int id);
}