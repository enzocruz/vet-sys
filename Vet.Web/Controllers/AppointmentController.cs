using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vet.DBContext;
using Microsoft.AspNetCore.Authorization;
using Vet.Web.Models.ViewModels;
using Vet.Web.Models;
namespace Vet.Web.Controllers
{
    [Authorize]
    public class AppointmentController : Controller
    {
        private VetDBContext _db;
        public AppointmentController(VetDBContext db){
            _db=db;
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View(new EventViewModel());
        }
        [HttpPost]
        public IActionResult Create(EventViewModel model)
        {
            if(ModelState.IsValid){
                try{
                    var d=DateTime.Parse(model.Date+" "+model.Time);
                  
                    var ec=_db.Appointments.Where(f=>f.AppointmentDate==d).ToList().Count();
                    
                    if(ec>=1){
                        throw new Exception(string.Format(@"There is already an appointment book on that day."));
                    }else{
                        _db.Appointments.Add(
                            new Appointment(){
                                Name=model.Name
                                ,Reason=model.Reason
                                ,AppointmentDate=d
                            }
                        );
                    }
                    _db.SaveChanges();
                    return RedirectToAction("index","home");

                    
                  
                }catch(Exception ex){
                    ModelState.AddModelError(string.Empty,ex.Message);
                    return View(model);
                }
            }
            return View(model);
        }
        public IActionResult View(int id){
            var ap=_db.Appointments.Find(id);
            return View(ap);
        }
    }
}