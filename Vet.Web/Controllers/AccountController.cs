using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vet.DBContext;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Vet.Web.Models.ViewModels;
namespace Vet.Web.Controllers
{
    public class AccountController : Controller
    {
        private VetDBContext _db;
        private SignInManager<IdentityUser> _signInManger;
        private UserManager<IdentityUser> _userMananger;
        public  AccountController(VetDBContext _db,UserManager<IdentityUser> userManager,SignInManager<IdentityUser> signInManager){
            this._db=_db;
            this._signInManger=signInManager;
            this._userMananger=userManager;
        }
        [HttpGet]
        public IActionResult Login(){
            return View(new LoginViewModel());
        }
        [HttpPost]
        public async Task<IActionResult>Login(LoginViewModel model){
            if(ModelState.IsValid){
                var result= await _signInManger.PasswordSignInAsync(model.Username,model.Password,true,false);
                if(result.Succeeded){
                    
                    return RedirectToAction("index","home");
                }
                ModelState.AddModelError(string.Empty,"Login attempted failed.");
                
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Register(){
            return View(new RegisterViewModel());
        }
        [HttpPost]
        public async Task<IActionResult>Register(RegisterViewModel model){
            if(ModelState.IsValid){
                var user=new IdentityUser{
                    UserName=model.Username
                    ,Email=null
                };
                var result=await _userMananger.CreateAsync(user,model.Password);
                if(result.Succeeded){
                    await _signInManger.SignInAsync(user,true);
                    return RedirectToAction("index","home");
                }
                foreach(var s in result.Errors){
                    ModelState.AddModelError(string.Empty,s.Description);
                }
                
            }
            return View(model);
        }
        public async Task<IActionResult>Logout(){
            await _signInManger.SignOutAsync();
            return RedirectToAction("login","account");
        }
       /*public IActionResult Index()
        {
            return View();
        }*/
    }
}