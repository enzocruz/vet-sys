namespace Vet.Web.Models.ViewModels;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
public class OwnerViewModel{
   [Required]
   public string Name{get;set;}
   [MaxLength(255)]
    public string Address{get;set;}
   [MaxLength(20)]
    public string ContactNumber{get;set;}
   
}