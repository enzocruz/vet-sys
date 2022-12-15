using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vet.DBContext;
using Vet.Web.Models.ViewModels;
using Vet.Web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
namespace Vet.Web.Controllers
{
   [Authorize]
    public class ItemController : Controller
    {
        private VetDBContext _db;
        public ItemController(VetDBContext db){
            _db=db;
        }
        public IActionResult Index(int page=1,string search="")
        {
            const int pagesize=10;
            if(page<1)
                page=1;
            var items=_db.Items
                .Include(f=>f.Type)
                .Where(f=>f.Name.ToLower().Contains(search))
                .ToList();
            int listcount=items.Count();
            Pager pager=new Pager(listcount,page,pagesize);
            int skip=(page-1)*pagesize;
            var mod=items.Skip(skip).Take(pagesize).ToList();
            ViewBag.PageViewModel=new PageViewModel(pager,"Index","Item",search);
            return View(mod);
           
        }
        [HttpGet]
        public IActionResult Create(){
            var types=_db.Types.ToList();
            ItemsViewModel model=new ItemsViewModel(){
                Types=types
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Create(ItemsViewModel model){
            if(!ModelState.IsValid){
                model.Types=_db.Types.ToList();
                return View(model);
            }
             Items item=new Items(){
                Name=model.Name
                ,ItemTypeId=model.TypeID
                ,Description=model.Description
                ,Price=model.Price
            };
            _db.Items.Add(item);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult TypeCreate(ItemTypeViewModel model){
            ItemType data=new ItemType(){
                Name=model.Name
                ,Description=model.Description
            };
            if(!ModelState.IsValid){
                return Json(new {Success=false,Errors=ModelState.Where(f=>f.Value.Errors.Count()>=1)
                .Select(f=>new {Key=f.Key,MSG=f.Value.Errors.ToList()})
                });
            }else{
                try{
                    _db.Types.Add(data);
                    _db.SaveChanges();
                }catch(Exception ex){
                    ModelState.AddModelError("Exception",ex.InnerException.Message);
                    return Json(new {Success=false,Errors=ModelState.Where(f=>f.Value.Errors.Count()>=1)
                    .Select(f=>new {Key=f.Key,MSG=f.Value.Errors.ToList()})
                    });
                }
               
            }
            
            return Json(new {Success=true,Data=data});
        }
        [HttpGet]
        public IActionResult Edit(int id){
            var TypeList=_db.Types.ToList();
            ItemsViewModel model=new ItemsViewModel();
            var item=_db.Items.Find(id);

            if(item!=null){
                model.Id=item.Id;
                model.Name=item.Name;
                model.Description=item.Description;
                model.TypeID=item.Id;
                model.Price=item.Price;
                model.Types=_db.Types.ToList();


            }else {
                return RedirectToAction("index");
            }
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(ItemsViewModel model){
            if(ModelState.IsValid){
                model.Types=_db.Types.ToList();
                Items item=new Items();
                item=_db.Items.Find(model.Id);
                try{
                    if(item!=null){
                        item.Name=model.Name;
                        item.ItemTypeId=model.TypeID;
                        item.Description=model.Description;
                        item.Price=model.Price;
                        _db.Items.Update(item);
                        _db.SaveChanges();
                    }
                }
                catch(Exception ex){
                    ModelState.AddModelError("Exception",ex.InnerException.Message);
                    return View(model);
                }
                return RedirectToAction("index");

            }
            return View(model);
        }
        

    }//end of class

    
}//end of namespace