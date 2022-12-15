namespace Vet.Web.Models.ViewModels;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
public class RegisterViewModel{
   [Required]
   public string Username{get;set;}
   [Required]
    public string Password{get;set;}
   
    [Required]
    [Compare("Password",ErrorMessage ="Passowrd does not matched")]
    public string ConfirmPassword{get;set;}
   
}