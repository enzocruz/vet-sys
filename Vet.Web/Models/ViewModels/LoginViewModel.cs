namespace Vet.Web.Models.ViewModels;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
public class LoginViewModel{
   [Required]
   public string Username{get;set;}
   [Required]
    public string Password{get;set;}
   
   
}