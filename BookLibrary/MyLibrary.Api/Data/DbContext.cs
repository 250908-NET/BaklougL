using Microsoft.EntityFrameworkCore;
using MyLibrary.Api.Models;

namespace MyLibrary.Api.Data;

public class MyLibraryDbContext : DbContext
{

    public DbSet<Book> Books { get; set; }
    public DbSet<Loan> Loans { get; set; }     

    public DbSet<User> Users { get; set; }

    public MyLibraryDbContext(DbContextOptions<MyLibraryDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}   