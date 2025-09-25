using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MyLibrary.Api.Models;

public class Book
{
    public int Id { get; set; }
    [Required]
    public string Title { get; set; } = string.Empty;
    [Required]
    public string Author { get; set; } = string.Empty;
    [Required]
    public string Genre { get; set; } = string.Empty;
    [Required]
    public int PublishedYear { get; set; }

    [JsonIgnore]
    public List<Loan> Loans { get; set; } = new List<Loan>();
}
