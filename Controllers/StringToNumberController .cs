using Microsoft.AspNetCore.Mvc;
using FirstLine.CodeChallenge.Models;
using System.Globalization;

namespace FirstLine.CodeChallenge.Controllers
{
    public class StringToNumberController : Controller
    {
        public IActionResult Index()
        {
            return View(new StringToNumberModel());
        }

        [HttpPost]
        public IActionResult Index(StringToNumberModel model)
        {
            if (ModelState.IsValid)
            {
                model.Result = ConvertToWords(model.Number!.Value);
            }

            return View(model);
        }

        private string ConvertToWords(decimal number)
        {
            return number.ToString("C2", CultureInfo.CreateSpecificCulture("en-US")) + " (" +
                   NumberToWords((int)number) + " and " +
                   ((int)(number * 100) % 100).ToString("00") + "/100 dollars)";
        }

        private string NumberToWords(int number)
        {
            if (number == 0)
            {
                return "zero";
            }

            string[] units =
            [
                "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve",
                "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen"
            ];
            string[] tens = ["", "", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety"];

            return number switch
            {
                < 20 => units[number],
                < 100 => tens[number / 10] + ((number % 10 != 0) ? " " + units[number % 10] : ""),
                < 1000 => units[number / 100] + " hundred" +
                          ((number % 100 != 0) ? " and " + NumberToWords(number % 100) : ""),
                _ => NumberToWords(number / 1000) + " thousand" +
                     (number % 1000 != 0 ? " " + NumberToWords(number % 1000) : "")
            };
        }
    }
}