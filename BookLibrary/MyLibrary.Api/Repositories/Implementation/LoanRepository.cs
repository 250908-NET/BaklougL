using MyLibrary.Api.Models;
using MyLibrary.Api.Data;

using Microsoft.EntityFrameworkCore;

namespace MyLibrary.Api.Repositories;



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

    public async Task<List<Loan>> GetAllLoansAsync()
    {
        return await _dbContext.Loans.ToListAsync();
    }

    public async Task<Loan?> UpdateLoanAsync(int id, Loan updatedLoan)
    {
        var existingLoan = await _dbContext.Loans.FindAsync(id);
        if (existingLoan == null)
        {
            return null;
        }

        _dbContext.Entry(existingLoan).CurrentValues.SetValues(updatedLoan);
        await _dbContext.SaveChangesAsync();

        return existingLoan;
    }

    public async Task<bool> DeleteLoanAsync(int id)
    {
        var loan = await _dbContext.Loans.FindAsync(id);
        if (loan != null)
        {
            _dbContext.Loans.Remove(loan);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        return false;
    }

}