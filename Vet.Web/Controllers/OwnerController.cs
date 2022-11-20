using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vet.DBContext;
namespace Vet.Web.Controllers
{
    public class OwnerController : Controller
    {
        private VetDBContext _db;
        public OwnerController(VetDBContext _db){
            this._db=_db;
        }
        public IActionResult Index()
        {            
            return View();
        }
    }
}