using System.ComponentModel.DataAnnotations;

namespace FirstLine.CodeChallenge.Models;

public class StringToNumberModel
{
    [Required(ErrorMessage = "Please enter a number.")]
    [Range(0, double.MaxValue, ErrorMessage = "Please enter a valid positive number.")]
    public decimal? Number { get; set; }

    public string? Result { get; set; }
}