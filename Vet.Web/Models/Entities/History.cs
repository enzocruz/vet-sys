namespace Vet.Web.Models;
using System.ComponentModel.DataAnnotations;

public class History{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Diagnosis {get;set;}
    [Required]
    public int DoctorId{get;set;}

    [Required]
    public double Temperature{get;set;}
    [Required]
    public int PetID {get;set;}
    
    [MaxLength(255,ErrorMessage ="You have exceed the maximum characters.")]
    public string? Hydration{get;set;}
 
    public Doctor Vet{get;set;}
    [Timestamp]
    public DateTime CreatedDate{get;set;}=DateTime.Now;

    public Pets Pet{get;set;}
     public List<Prescription> Prescription{get;set;}
     public List<Vacination> Vacination{get;set;}
}