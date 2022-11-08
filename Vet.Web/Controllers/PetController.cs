using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vet.DBContext;
using Microsoft.EntityFrameworkCore;
using Vet.Web.Models.ViewModels;
using Vet.Web.Models;
namespace Vet.Web.Controllers
{
   
    public class PetController : Controller
    {
        private readonly VetDBContext _db;
        public PetController(VetDBContext db){
            _db=db;
        }
        public IActionResult Index(int page=1)
        {   
            const int pagesize=1;
            if(page<1)
                page=1;
            

            var pets=_db.Pets
            .Include(b=>b.Breed)
            .ThenInclude(a=>a.Animal)
            .Include(f=>f.Owner)
            .Include(f=>f.MedicalHistory)
            .ToList();
            int listcount=pets.Count();

            Pager pager=new Pager(listcount,page,pagesize);
           
            int skip=(page-1)*pagesize;
            ViewBag.PageViewModel=new PageViewModel(pager,"Index","Pet");
            
            return View(pets.Skip(skip).Take(pagesize).ToList());
        }
        [HttpGet]
        public IActionResult Create(){
            var model= new PetsCreateViewModel(){
                Owners=_db.Owners.ToList()
                ,Breeds=_db.Breeds.ToList()
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Create(PetsCreateViewModel model){
            if(!ModelState.IsValid){
                model.Owners=_db.Owners.ToList();
                model.Breeds=_db.Breeds.ToList();
                return View(model);
            }else{
                var pet =new Pets(){
                    Name=model.Name
                    ,Age=model.Age
                    ,BreedID=model.BreedID
                    ,OwnerID=model.OwnerID
                    ,DOB=model.DOB
                    ,Sex=model.Sex
                };
                _db.Pets.Add(pet);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            
        }
        public IActionResult OwnerCreate(OwnerViewModel model){
        Models.Owners data=new Models.Owners(){
                Name=model.Name
                ,ContactNumber=model.ContactNumber
                ,Address=model.Address
        };
        if(!ModelState.IsValid){
            return Json(new {Success=false,Errors=ModelState.Where(f=>f.Value.Errors.Count()>=1).Select(f=>new {Key=f.Key,MSG=f.Value.Errors.ToList()})
                });
        }else{
            _db.Owners.Add(data);
            _db.SaveChanges();
        }
        
        return Json(new {Success=true,Data=data});
        }
    }
}