using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vet.DBContext;
using Microsoft.EntityFrameworkCore;
using Vet.Web.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
namespace Vet.Web.Controllers
{
    [Authorize]
    public class OwnerController : Controller
    {
        private VetDBContext _db;
        public OwnerController(VetDBContext _db){
            this._db=_db;
        }
        [HttpGet]
        public IActionResult Index(int page=1,string search="")
        {           
            const int pagesize=5;
            if(page<1)
                page=1;
            var owners=_db.Owners.Where(f=>f.Name.ToLower().Contains(search))
            .Include(f=>f.Pets)
            .ToList();
            int listcount=owners.Count();
            Pager pager=new Pager(listcount,page,pagesize);
            int skip=(page-1)*pagesize;
            var mod=owners.Skip(skip).Take(pagesize).ToList();

            ViewBag.PageViewModel=new PageViewModel(pager,"Index","Owner",search);
            return View(mod);
        }
        [HttpGet]
        public ActionResult Edit(int id){
            string source_url= "";
            if( Request.GetTypedHeaders().Referer!=null){
                source_url= Request.GetTypedHeaders().Referer.ToString();
            }
            
            var model=_db.Owners
            .Where(f=>f.Id==id)
            .Include(f=>f.Pets)
            .ThenInclude(f=>f.Breed)
            .Select(f=>new EditOwnerViewModel(){
                Id=f.Id
                ,Name=f.Name
                ,Address=f.Address
                ,Pets=f.Pets
                ,ContactNumber=f.ContactNumber
            })
            .FirstOrDefault();
            
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(EditOwnerViewModel model){
             
            try{
                
                if(ModelState.IsValid){
                    var p=_db.Owners.Find(model.Id);

                    if(p!=null){
                        p.Id=model.Id;
                        p.Name=model.Name;
                        p.Address=model.Address;
                        p.ContactNumber=model.ContactNumber;
                        _db.Owners.Update(p);
                        _db.SaveChanges();
                    }
                }else{
                    model.Pets=_db.Pets.Where(f=>f.OwnerID==model.Id)
                    .Include(f=>f.Breed).ToList();
                    return View(model);
                }
                
            }catch(Exception ex){
                ModelState.AddModelError("Exception",ex.InnerException.Message);
                return View(model);
            }
           
            return RedirectToAction("Index");
        }
    }
}