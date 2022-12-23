using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
namespace Vet.Web.Models.ViewModels;

public class CheckUpViewModel{
    [ValidateNever]
    public int ID{get;set;}
    [ValidateNever]
    public Pets Pets { get; set; }

    [ValidateNever]
    public List<Doctor> Doctors{get;set;}
     [Required]
    public string Diagnosis {get;set;}
    [Required]
    public int DoctorId{get;set;}
    [Required]
    public double Temperature{get;set;}
 
    [MaxLength(255,ErrorMessage ="You have exceed the maximum characters.")]
    public string? Hydration{get;set;}
    
    [ValidateNever]
    public List<SelectItems<int>> Items{get;set;}

    [ValidateNever]
    public List<int> IDS{get;set;}=new List<int>();
    
     [ValidateNever]
    public List<string> Desc{get;set;}=new List<string>();
   
}