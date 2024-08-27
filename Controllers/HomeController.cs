using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FirstLine.CodeChallenge.Models;

namespace FirstLine.CodeChallenge.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IEnumerable<ExerciseLinkModel> _exercises;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
        _exercises = new List<ExerciseLinkModel>
        {
            new()
            {
                Id = 1,
                Title = "String to Number",
                Description = "Convert amount to string representation",
                Controller = "StringToNumber",
                Action = "Index"
            },
            new()
            {
                Id = 6,
                Title = "Palindrome Checker",
                Description = "Check if a positive number is a palindrome",
                Controller = "PalindromeChecker",
                Action = "Index"
            }
        };
    }

    public IActionResult Index()
    {
        return View(_exercises);
    }

    public IActionResult About()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}