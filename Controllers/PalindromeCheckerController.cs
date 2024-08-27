using Microsoft.AspNetCore.Mvc;
using FirstLine.CodeChallenge.Models;

namespace FirstLine.CodeChallenge.Controllers
{
    public class PalindromeCheckerController : Controller
    {
        public IActionResult Index()
        {
            return View(new PalindromeModel());
        }

        [HttpPost]
        public IActionResult Index(PalindromeModel model)
        {
            if (ModelState.IsValid)
            {
                model.IsPalindrome = IsPalindrome(model.Number!.Value);
            }
            return View(model);
        }

        private bool IsPalindrome(int number)
        {
            string numberString = number.ToString();
            return numberString.SequenceEqual(numberString.Reverse());
        }
    }
}