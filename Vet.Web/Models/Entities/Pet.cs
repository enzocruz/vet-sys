namespace Vet.Web.Models;
using System.ComponentModel.DataAnnotations;
public class Pets{
   [Key]
    public int Id { get; set; }
    [Required]
    public String Name { get; set; }

    //public Breeds Breed{get;set;}
    public int BreedID{get;set;}
    public DateTime CreatedDate{get;set;}=DateTime.Now;
    

}