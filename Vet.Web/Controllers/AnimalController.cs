using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Vet.Web.Models;
using Vet.DBContext;
using Microsoft.EntityFrameworkCore;
using Vet.Web.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
namespace Vet.Web.Controllers;

[Authorize]
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
        var model=new BreedsViewModel(){
            Animals=_db.Animals.ToList()
        };
       

        return View(model);
    }

    [HttpPost]

    public IActionResult Create(BreedsViewModel model){
       if(!ModelState.IsValid){
        model.Animals= _db.Animals.ToList();
    
        return View(model);
       }else{
            _db.Breeds.Add(new Breeds(){
                Name=model.Name
                ,AnimalID=model.AnimalID
            } );
            _db.SaveChanges();
       }
        return RedirectToAction("Index");
    }
     [HttpPost]

    public IActionResult AnimalCreate(AnimalViewModel model){
       Models.Animal animal=new Models.Animal(){
            Name=model.Name
       };
       if(!ModelState.IsValid){
        return Json(new {Success=false,Errors=ModelState.Where(f=>f.Value.Errors.Count()>=1).Select(f=>new {Key=f.Key,MSG=f.Value.Errors.ToList()})
            });
       }else{
           _db.Animals.Add(animal);
           _db.SaveChanges();
       }
    
       return Json(new {Success=true,Data=animal});
    }

   
}
