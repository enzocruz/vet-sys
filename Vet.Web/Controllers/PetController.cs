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
        public IActionResult Index(int page=1,string search="")
        {   
            const int pagesize=10;
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
            ViewBag.PageViewModel=new PageViewModel(pager,"Index","Pet",search);
            
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
            model.Owners=_db.Owners.ToList();
            model.Breeds=_db.Breeds.ToList();
            if(!ModelState.IsValid){
                
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
               
                
               try{
                    _db.Pets.Add(pet);
                    _db.SaveChanges();
               }catch (Exception ex){
                    ModelState.AddModelError("Exception",ex.InnerException.Message);
                    return View(model);
               }
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
        [HttpGet]
        public IActionResult Edit(int id){
            string source_url= "";
            if( Request.GetTypedHeaders().Referer!=null){
                source_url= Request.GetTypedHeaders().Referer.ToString();
            }
            EditPetsViewModel model=new EditPetsViewModel();
            var r=_db.Pets.Where(f=>f.Id==id)
                .Select(f=>new EditPetsViewModel(){
                   Name=f.Name
                   ,Id=f.Id
                    ,Age=f.Age
                    ,BreedID=f.BreedID
                    ,OwnerID=f.OwnerID
                    ,DOB=f.DOB
                    ,Sex=f.Sex
                })
                .FirstOrDefault();
            if(r!=null){
                model=r;
            }
            model.Breeds=_db.Breeds.ToList();
            model.Owners=_db.Owners.ToList();
            model.SourceURL=source_url;
            return View(model);

        }
        [HttpPost]
        public IActionResult Edit(EditPetsViewModel model){
            
            
            try{
                if(ModelState.IsValid){
                    var p=_db.Pets.Find(model.Id);
                
                    if(p!=null){
                        p.Name=model.Name;
                        p.Age=model.Age;
                        p.BreedID=model.BreedID;
                        p.DOB=model.DOB;
                        p.OwnerID=model.OwnerID;
                    
                        _db.Pets.Update(p);
                        _db.SaveChanges();
                    }
                }
                model.Breeds=_db.Breeds.ToList();
                model.Owners=_db.Owners.ToList();
            }catch(Exception ex){
                ModelState.AddModelError("Exception",ex.InnerException.Message);
                return View(model);
            }
            Console.WriteLine("URL:"+model.SourceURL);
            if(!string.IsNullOrEmpty(model.SourceURL) && !string.IsNullOrWhiteSpace(model.SourceURL)){
                return Redirect(model.SourceURL);
            }
            return RedirectToAction("Index");
           
        }
    }
}