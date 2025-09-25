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
   
}