using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Vet.Web.Models;
using Vet.DBContext;
namespace Vet.Web.Controllers;
using Microsoft.EntityFrameworkCore;
public class Animal : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly VetDBContext _db;

    public Animal(ILogger<HomeController> logger,VetDBContext db)
    {
        _logger = logger;
        _db=db;
    }        

    public IActionResult Index()
    {
        var breeds=_db.Breeds
        .Include(b=>b.Animal)
        .ToList();

        return View(breeds);
    }
    [HttpGet]
      public IActionResult Create()
    {
        

        return View();
    }

   
}
