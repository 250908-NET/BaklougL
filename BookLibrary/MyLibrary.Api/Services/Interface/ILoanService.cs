using MyLibrary.Api.Models;
using MyLibrary.Api.Data;

namespace MyLibrary.Api.Services;
 
public interface ILoanService
{
   
    public Task<List<Loan>> GetLoansByUserIdAsync(int userId);
    public Task<Loan> AddLoanAsync(Loan loan);
}