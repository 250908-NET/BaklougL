using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MyLibrary.Api.Models;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public string Genre { get; set; } = string.Empty;
    public string AvailabilityStatus { get; set; } = "Available";
    public int PublishedYear { get; set; }

    public List<Loan> Loans { get; set; } = new List<Loan>();
}