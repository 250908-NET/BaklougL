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


    public Task<List<Loan>> GetLoansByUserIdAsync(int userId) => _loanRepository.GetLoansByUserIdAsync(userId);

    public async Task<Loan> AddLoanAsync(Loan loan)
    {

        await _loanRepository.AddLoanAsync(loan);
        return loan;
    }


    public async Task<Loan?> UpdateReturnDateAsync(int loanId, DateTime returnDate)
    {
       return await _loanRepository.UpdateReturnDateAsync(loanId, returnDate);
    }

}