using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vet.DBContext;
using Vet.Web.Models.ViewModels;
using Vet.Web.Models;
using Microsoft.EntityFrameworkCore;
namespace Vet.Web.Controllers
{
   
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
        

    }
}