using System.ComponentModel.DataAnnotations;

namespace TodoApi.Models;

public class User
{
    [Key]
    public long User_Id { get; set; }
    public string? Name { get; set; }
    public string? Plain_Password { get; set; }

    public double CurrencyA { get; set; } = 1000.0;
    public double CurrencyB { get; set; } = 1000.0;
}