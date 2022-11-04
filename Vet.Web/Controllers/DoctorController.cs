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
    

    public class DoctorController : Controller
    {
        protected VetDBContext _db;
        public DoctorController (VetDBContext dBContext){
            _db=dBContext;
        }
        public IActionResult Index()
        {
            var model=_db.Doctors.ToList();
            return View(model);
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
    }
}