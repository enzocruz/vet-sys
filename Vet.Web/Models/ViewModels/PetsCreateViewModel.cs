namespace Vet.Web.Models.ViewModels;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
public class PetsCreateViewModel{
    [Required(ErrorMessage ="Name is required")]
    [MaxLength(100,ErrorMessage ="Name max lenght is only 100 characters")]
    [MinLength(5,ErrorMessage ="Name must be atleast 5 characters long")]
    public string Name { get; set; }
    [Required(ErrorMessage ="Breed is required")]
    public int BreedID{get;set;}
   [Required(ErrorMessage ="Sex is Required")]
    public Int16 Sex{get;set;}
    [Required(ErrorMessage ="Date of Birth is Required")]
    public DateOnly DOB{get;set;}
    [Required(ErrorMessage ="Onwer is required")]
    public int OwnerID{get;set;}
    [Required(ErrorMessage ="Age is required")]
    public int Age{get;set;}
    [ValidateNever]
    public IEnumerable<Owners> Owners{get;set;}
    [ValidateNever]
    public IEnumerable<Breeds> Breeds {get;set;}

   
}