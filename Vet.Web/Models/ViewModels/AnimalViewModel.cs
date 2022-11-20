namespace Vet.Web.Models.ViewModels;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
public class AnimalViewModel{
    [Required]
    [MaxLength(100,ErrorMessage ="Name must be less than 100 character long.")]
  
    public string Name { get; set; }

    public string? Description{get;set;}
}