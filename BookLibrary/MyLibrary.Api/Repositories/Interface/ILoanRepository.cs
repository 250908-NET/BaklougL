using MyLibrary.Api.Models;


namespace MyLibrary.Api.Repositories;


public interface ILoanRepository
{
    public Task<List<Loan>> GetAllLoansAsync();
    public Task<Loan?> GetLoanByIdAsync(int id);
    public Task<Loan> AddLoanAsync(Loan loan);
  
    public Task<Loan?> UpdateLoanAsync(int id, Loan updatedLoan);
    public Task<bool> DeleteLoanAsync(int id);
}