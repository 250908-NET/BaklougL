using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MyLibrary.Api.Models;

public class User
{
    public int Id { get; set; }
    [Required]
    [MaxLength(50)]
    public string Username { get; set; } = string.Empty;
    [Required]
    public string Email { get; set; } = string.Empty;
    [Required]
    public string CurrentlyBorrowedBooks { get; set; } = string.Empty;

    public List<Loan> Loans { get; set; } = new List<Loan>();
}