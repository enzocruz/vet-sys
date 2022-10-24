namespace Vet.Web.Models;
using System.ComponentModel.DataAnnotations;

public class History{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Diagnosis {get;set;}

    public int DoctorId{get;set;}

  

    public double Temperature{get;set;}

    public int? ItemID{get;set;}

    public string? Hydration{get;set;}
    [MaxLength(255)]

    public string? Vacination{get;set; }

    public Doctor Vet{get;set;}
    [Timestamp]
     public DateTime CreatedDate{get;set;}=DateTime.Now;
}