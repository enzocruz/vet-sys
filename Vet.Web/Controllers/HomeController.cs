using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Vet.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Vet.DBContext;
using Vet.Web.Models.ViewModels;
namespace Vet.Web.Controllers;

[Authorize]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private VetDBContext _db;
    public HomeController(ILogger<HomeController> logger,VetDBContext db)
    {
        _logger = logger;
        _db=db;
    }

    public IActionResult Index()
    {
        var e=_db.Appointments.OrderByDescending(f=>f.AppointmentDate).Select(f=>new CalendarEventViewModel(){
            title=string.Format("{0} ({1})",f.Name,f.Reason)
            ,start=f.AppointmentDate.ToString("s")
            ,ID=f.Id
        }).ToList();
        return View(e);
    }

  

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
