namespace Vet.Web.Models;
using System.ComponentModel.DataAnnotations;
public class Breeds{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public String Name{get;set;}

    public Animal Animal{get;set;}
   
    public int AnimalID{get;set;}
     [Timestamp]
     public DateTime CreatedDate{get;set;}=DateTime.Now;

    public ICollection<Pets> Pets{get;set;}
}