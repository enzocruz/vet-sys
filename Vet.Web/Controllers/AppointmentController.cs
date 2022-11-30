using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vet.DBContext;
namespace Vet.Web.Controllers
{

    public class AppointmentController : Controller
    {
        private VetDBContext _db;
        public AppointmentController(VetDBContext db){
            _db=db;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}