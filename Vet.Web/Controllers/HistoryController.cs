using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vet.DBContext;
using Vet.Web.Models;
using Vet.Web.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
namespace Vet.Web.Controllers
{
    [Authorize]
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
                ViewBag.PageViewModel=new PageViewModel(pager,"Index","History","");
            }

            return View(pet);
            
        }
        [HttpGet]
        public IActionResult Create(int id){
            var model=new CheckUpViewModel();
            var p=_db.Pets.Where(f=>f.Id==id)
                .Include(f=>f.Owner)
                .Include(f=>f.Breed)
                .FirstOrDefault(); 
            model.Doctors=_db.Doctors.ToList();
            model.ID=id;
            if(p==null){
                return RedirectToAction("View","History",new{id=id});
            }
            model.Pets=p;
            model.Items=_db.Items
            .Include(f=>f.Type).Select(f=>new SelectItems<int>(){
                Value=f.Id
                ,Text=string.Format(@"{0}({1})",f.Name,f.Type.Name)
            }).ToList();
            //model.ItemList=new List<Items>();

            return View(model);
        }
        [HttpPost]
        public IActionResult Create(CheckUpViewModel model){
            
           
            var p=_db.Pets.Where(f=>f.Id==model.ID)
                .Include(f=>f.Owner)
                .Include(f=>f.Breed)
                .FirstOrDefault(); 
            model.Doctors=_db.Doctors.ToList();
            if(p==null){
                return RedirectToAction("View","History",new{id=model.ID});
            }
            
            model.Pets=p;
            model.Items=_db.Items
            .Include(f=>f.Type).Select(f=>new SelectItems<int>(){
                Value=f.Id
                ,Text=string.Format(@"{0}({1})",f.Name,f.Type.Name)
            }).ToList();
            if(ModelState.IsValid){
                using(var trans=_db.Database.BeginTransaction()){
                    try{
                        var h =new History(){
                            PetID=model.ID
                            ,DoctorId=model.DoctorId
                            ,Temperature=model.Temperature
                            ,Hydration=model.Hydration
                            ,Diagnosis=model.Diagnosis
                            
                        };
                        _db.History.Add(h);
                        _db.SaveChanges();
                        for(int i=0;i<=model.IDS.Count()-1;i++){
                            var item=_db.Items.Include(f=>f.Type)
                                .Where(f=>f.Id==model.IDS[i]).FirstOrDefault();
                            if(item!=null){

                                if(item.Type.Name.ToLower().Contains("vaccine")){
                                    _db.Vacinations.Add(new Vacination(){
                                        PetID=model.ID
                                        ,HistoryID=h.Id
                                        ,Description=model.Desc[i]
                                        ,ItemID=item.Id

                                    });
                                }else{
                                    _db.Prescriptions.Add(new Prescription(){
                                        PetID=model.ID
                                        ,HistoryID=h.Id
                                        ,Description=model.Desc[i]
                                        ,ItemID=item.Id
                                        
                                    });
                                }
                            }
                        }
                        _db.SaveChanges();
                        trans.Commit();
                        return RedirectToAction("View","History",new{id=model.ID});
                    }catch(Exception ex){
                        trans.Rollback();
                        ModelState.AddModelError(string.Empty,ex.Message.ToString());
                        return View(model);
                    }
                }
               
            }
            return View(model);
        }
        [Route("/history/vaccination/{id}")]
        public IActionResult ViewVac(int id,int page=1){
        
            var pet=_db.Pets
                .Include(f=>f.Owner)
                .Include(f=>f.Breed)
                .Where(f=>f.Id==id)
                .FirstOrDefault();
            var model=new VacHistoryViewModel();
            if(pet!=null)
                model.Pet=pet;
            model.Vaccination=_db.Vacinations
                .Include(f=>f.Item)
                .Include(f=>f.History)
                .ThenInclude(f=>f.Vet)
                .OrderByDescending(f=>f.CreatedDate)
                .ToList();
            const int pagesize=10;
            if(page<1)
                page=1;
           
            if(pet!=null){
                int listcount=model.Vaccination.Count();
                Pager pager=new Pager(listcount,page,pagesize);
                int skip=(page-1)*pagesize;
               model.Vaccination=model.Vaccination.Skip(skip).Take(pagesize).ToList();
                ViewBag.PageViewModel=new PageViewModel(pager,"Index","Doctor","");
            }
           
           return View(model);
        }
        [Route("/Records/{id}")]
        public IActionResult ViewRecord(int id){
            var history=_db.History
                .Where(f=>f.Id==id)
                .Include(f=>f.Vet)
                .Include(f=>f.Pet.Owner)
                .Include(f=>f.Pet.Breed)
                .Include(f=>f.Vacination)
                .ThenInclude(f=>f.Item.Type)
                .Include(f=>f.Prescription)
                .ThenInclude(f=>f.Item.Type)
                .FirstOrDefault();

                
            return View(history);

        }
    }
}