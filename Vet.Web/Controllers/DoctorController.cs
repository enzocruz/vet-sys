using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vet.DBContext;
using Vet.Web.Models.ViewModels;
using Vet.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Vet.Web.Controllers
{
    
    [Authorize]
    public class DoctorController : Controller
    {
        protected VetDBContext _db;
        public DoctorController (VetDBContext dBContext){
            _db=dBContext;
        }
        public IActionResult Index( int page=1,string search="")
        {

            const int pagesize=10;
            if(page<1)
                page=1;
            var doctors=_db.Doctors.Where(f=>f.Name.ToLower().Contains(search)).ToList();
            int listcount=doctors.Count();
            Pager pager=new Pager(listcount,page,pagesize);
            int skip=(page-1)*pagesize;
            var mod=doctors.Skip(skip).Take(pagesize).ToList();
            ViewBag.PageViewModel=new PageViewModel(pager,"Index","Doctor",search);
            return View(mod);
           
        }
        [HttpGet]
        public IActionResult Create(){
            DoctorFormViewModel model=new DoctorFormViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(DoctorFormViewModel model){
            if(!ModelState.IsValid){
                return View(model);
            }
            Doctor doctor=new Doctor(){
                Name=model.Name
                ,Address=model.Address
                ,License=model.License
                ,Number=model.ContactNumber
            };
            _db.Doctors.Add(doctor);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id){
            var doctor=_db.Doctors.Find(id);
            var model=new EditDoctorViewModel();
            if(doctor!=null){
                model.Name=doctor.Name;
                model.Id=doctor.Id;
                model.License=doctor.License;
                model.Address=doctor.Address;
                model.ContactNumber=doctor.Number;
           
            }
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(EditDoctorViewModel model){
            var doctor=_db.Doctors.Find(model.Id);
            if(ModelState.IsValid){
                try{
                   if(doctor!=null){
                        doctor.Name=model.Name;
                        doctor.Address=model.Address;
                        doctor.Number=model.ContactNumber;
                        _db.Doctors.Update(doctor);
                        _db.SaveChanges();
                        return RedirectToAction("index");
                   }    

                }catch(Exception ex){
                    ModelState.AddModelError("Exceptions",ex.InnerException.Message.ToString());
                    return View(model);
                }

            }

            return View(model);
        }
    }
}