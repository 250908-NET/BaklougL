using MyLibrary.Api.Models;
using MyLibrary.Api.Data;

namespace MyLibrary.Services;
public class LoanService : ILoanService
{
    private readonly ILoanRepository _loanRepository;
    public LoanService(ILoanRepository loanRepository)
    {
        _loanRepository = loanRepository;
    }

    Task<List<Loan>> GetAllLoansAsync() => _loanRepository.GetAllLoansAsync();

    Task<Loan?> GetLoanByIdAsync(int id) => _loanRepository.GetLoanByIdAsync(id);

    async Task<Loan> AddLoanAsync(Loan loan)
    {
        await _loanRepository.AddLoanAsync(loan);
        await _loanRepository.SaveChangesAsync();
        return loan;
    }

    Task<Loan?> UpdateLoanAsync(int id, Loan updatedLoan) => _loanRepository.UpdateLoanAsync(id, updatedLoan);

    Task<bool> DeleteLoanAsync(int id) => _loanRepository.DeleteLoanAsync(id);
}