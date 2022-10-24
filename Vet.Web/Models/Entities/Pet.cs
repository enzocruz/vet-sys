namespace Vet.Web.Models;
using System.ComponentModel.DataAnnotations;
public class Pets{
   [Key]
    public int Id { get; set; }
    [Required]
   [MaxLength(100)]
    public String Name { get; set; }
    public int BreedID{get;set;}
    
    public Int16 Sex{get;set;}
    
    public DateOnly DOB{get;set;}

    public int OwnerID{get;set;}
    
    public int Age{get;set;}

    public Owners Owner{get;set;}

    public Breeds Breed {get;set;}

    public ICollection<History> MedicalHistory{get;set;}
    [Timestamp]
     public DateTime CreatedDate{get;set;}=DateTime.Now;

}