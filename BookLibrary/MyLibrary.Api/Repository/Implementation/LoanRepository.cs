using MyLibrary.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace MyLibrary.Api.Repository;



public class LoanRepository : ILoanRepository
{
    private readonly MyLibraryDbContext _dbContext;

    public LoanRepository(MyLibraryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Loan> AddLoanAsync(Loan loan)
    {
        _dbContext.Loans.Add(loan);
        await _dbContext.SaveChangesAsync();
        return loan;
    }

    public async Task<Loan?> GetLoanByIdAsync(int id)
    {
        return await _dbContext.Loans.FindAsync(id);
    }

    public async Task<IEnumerable<Loan>> GetAllLoansAsync()
    {
        return await _dbContext.Loans.ToListAsync();
    }

    public async Task UpdateLoanAsync(Loan loan)
    {
        _dbContext.Loans.Update(loan);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteLoanAsync(int id)
    {
        var loan = await _dbContext.Loans.FindAsync(id);
        if (loan != null)
        {
            _dbContext.Loans.Remove(loan);
            await _dbContext.SaveChangesAsync();
        }
    }
}