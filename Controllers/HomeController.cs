using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ChefNDishes.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;

namespace ChefNDishes.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private ChefDbContext _context;
    public HomeController(ILogger<HomeController> logger, ChefDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        List<Chef> NewListChef = _context.chefs.Include(c => c.CreatedDishes).ToList();
        ViewBag.Checa = NewListChef;

        return View();
    }
    [HttpGet("chefs/new")]
    public IActionResult AddChef()
    {
        return View("AddChefs");
    }
    [HttpPost("chefs/create")]
    public IActionResult CreateChef(Chef newChef)
    {
        if (ModelState.IsValid)
        {
            _context.Add(newChef);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        else
        {
            return View("AddChefs", newChef);
        }
    }
    [HttpGet("dishes")]
    public IActionResult VerPlatos()
    {
        List<Dish> ListDishes = _context.dishes.Include(d => d.Creator).ToList();
        ViewBag.dishes = ListDishes;
        return View("Dishes");
    }
    [HttpGet("dishes/new")]
    public IActionResult AddDishes()
    {
        ViewBag.ListaC = _context.chefs.ToList(); ;
        return View("AddDishes");
    }

    [HttpPost("dishes/create")]
    public IActionResult CreateDishes(Dish newDish)
    {
        ViewBag.ListaC = _context.chefs.ToList(); ;
        if (ModelState.IsValid)
        {
            _context.Add(newDish);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        else
        {
            Console.WriteLine("Cagamos Papito");
            return View("AddDishes", newDish);
        }
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
