namespace Vet.Web.Models.ViewModels;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
public class BreedsViewModel{
     [Required]
     [MaxLength(100)]
     public string Name{get;set;}

    public String? Description{get;set;}

    public int AnimalID{get;set;}
    [ValidateNever]
    public List<Animal> Animals{get;set;}
}