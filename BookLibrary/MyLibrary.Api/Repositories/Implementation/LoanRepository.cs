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



    public async Task<List<Loan>> GetLoansByUserIdAsync(int userId)
    {
        var loans = await _dbContext.Loans
                            .Where(l => l.UserId == userId)
                            .ToListAsync();
        return loans;
    }


    public async Task<Loan> AddLoanAsync(Loan loan)
    {
        _dbContext.Loans.Add(loan);
        await _dbContext.SaveChangesAsync();
        return loan;
    }


    public async Task<Loan?> UpdateReturnDateAsync(int loanId, DateTime returnDate)
    {
        var loan = await _dbContext.Loans.FindAsync(loanId);
        if (loan == null) return null;

        loan.ReturnDate = returnDate;
        await _dbContext.SaveChangesAsync();

        return loan;
    }

}