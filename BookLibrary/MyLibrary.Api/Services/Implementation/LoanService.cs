using MyLibrary.Api.Models;
using MyLibrary.Api.Repositories;

namespace MyLibrary.Api.Services;
public class LoanService : ILoanService
{
    private readonly ILoanRepository _loanRepository;
    public LoanService(ILoanRepository loanRepository)
    {
        _loanRepository = loanRepository;
    }

    public Task<List<Loan>> GetAllLoansAsync() => _loanRepository.GetAllLoansAsync();

    public Task<Loan?> GetLoanByIdAsync(int id) => _loanRepository.GetLoanByIdAsync(id);

    public async Task<Loan> AddLoanAsync(Loan loan)
    {
        await _loanRepository.AddLoanAsync(loan);
        return loan;
    }

    public Task<Loan?> UpdateLoanAsync(int id, Loan updatedLoan) => _loanRepository.UpdateLoanAsync(id, updatedLoan);

    public Task<bool> DeleteLoanAsync(int id) => _loanRepository.DeleteLoanAsync(id);
}