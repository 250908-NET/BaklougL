using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MyLibrary.Api.Models;


public class Loan
{
    public int Id { get; set; }
    [Required]
    public int UserId { get; set; }
    [Required]
    public int BookId { get; set; }
    [Required]
    public DateTime LoanDate { get; set; } = DateTime.Now;
    public DateTime? ReturnDate { get; set; }

    [JsonIgnore]
    public User? User { get; set; }
    [JsonIgnore]
    public Book? Book { get; set; }
}
