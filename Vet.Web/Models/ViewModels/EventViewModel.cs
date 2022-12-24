namespace Vet.Web.Models.ViewModels;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
public class EventViewModel{
  
    [Required]
    [MaxLength(30,ErrorMessage ="Name is too loog, only 30 characters are allowed.")]
    public string Name{get;set;}
    [Required]
    public String Date{get;set;}
    [Required]
    public string Time{get;set;}
    [Required]
    [MaxLength(255,ErrorMessage ="Reason is to long, 255 is the max lenght.")]
    public string Reason{get;set;}
   
    
    
}