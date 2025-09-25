using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MyLibrary.Api.Models;

public class User
{
    public int Id { get; set; }

    public string Name { get; set; }

    public List<Loan> Loans { get; set; } = new List<Loan>();
}
