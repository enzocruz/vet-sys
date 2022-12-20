using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vet.DBContext;
using Vet.Web.Models;
using Vet.Web.Models.ViewModels;
namespace Vet.Web.Controllers
{
    public class HistoryController : Controller
    {
        private VetDBContext _db;
        public HistoryController(VetDBContext db){
            this._db=db;
        } 
        public IActionResult View(int id,int page=1)
        {
            const int pagesize=10;
            if(page<1)
                page=1;
            var pet=_db.Pets
                .Include(f=>f.Breed.Animal)
          
                .Include(f=>f.Owner)
                .Include(f=>f.MedicalHistory)
                
                .ThenInclude(f=>f.Vet)
                
                .Where(f=>f.Id==id).FirstOrDefault();
            if(pet!=null){
                int listcount=pet.MedicalHistory.Count();
                Pager pager=new Pager(listcount,page,pagesize);
                int skip=(page-1)*pagesize;
                pet.MedicalHistory=pet.MedicalHistory.Skip(skip).Take(pagesize).ToList();
                ViewBag.PageViewModel=new PageViewModel(pager,"Index","Doctor","");
            }

            return View(pet);
            
        }

        public IActionResult Create(int id){
            var model=new CheckUpViewModel();
            var p=_db.Pets.Where(f=>f.Id==id)
                .Include(f=>f.Owner)
                .Include(f=>f.Breed)
                .FirstOrDefault(); 
            model.Doctors=_db.Doctors.ToList();
            if(p==null){
                return RedirectToAction("View","History",new{id=id});
            }
            model.Pets=p;
            model.Items=_db.Items.ToList();
            

            return View(model);
        }
    }
}