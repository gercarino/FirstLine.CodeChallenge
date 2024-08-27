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
            new() { Id = 1, Title = "String to Number", Description = "Convert amount to string representation", Controller = "StringToNumber", Action = "Index" },
            new() { Id = 2, Title = "Exercise 2", Description = "Evaluate poker hand rank" },
            new() { Id = 3, Title = "Exercise 3", Description = "Print integers in spiral format" },
            new() { Id = 4, Title = "Exercise 4", Description = "Game of Life implementation" },
            new() { Id = 5, Title = "Exercise 5", Description = "Templating engine" },
            new() { Id = 6, Title = "Exercise 6", Description = "Check if number is palindrome" }
        };
    }

    public IActionResult Index()
    {
        return View(_exercises);
    }
    
    public IActionResult Exercise(int id)
    {
        var exercise = _exercises.FirstOrDefault(e => e.Id == id);
        if (exercise == null)
        {
            return NotFound();
        }
        return View(exercise);
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