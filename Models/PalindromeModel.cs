using System.ComponentModel.DataAnnotations;

namespace FirstLine.CodeChallenge.Models
{
    public class PalindromeModel
    {
        [Required(ErrorMessage = "Please enter a number.")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a positive number.")]
        public int? Number { get; set; }

        public bool? IsPalindrome { get; set; }
    }
}