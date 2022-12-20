using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
namespace Vet.Web.Models.ViewModels;

public class CheckUpViewModel{
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
 
    public Doctor Vet{get;set;}
    [Timestamp]
    public DateTime CreatedDate{get;set;}=DateTime.Now;

    public List<Items> Items{get;set;}

   
}