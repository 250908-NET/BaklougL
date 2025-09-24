using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MyLibrary.Api.Models;

public class Loan
{
    public int LoanId { get; set; }

    [Required]
    public int BookId { get; set; }
    [Required]
    public int UserId { get; set; }
    [Required]
    public DateTime LoanDate { get; set; }
    [Required]
    public DateTime? ReturnDate { get; set; }
    
    
}