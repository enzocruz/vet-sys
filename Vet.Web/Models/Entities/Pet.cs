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
    
    public DateTime DOB{get;set;}

    public int OwnerID{get;set;}
    
    public int Age{get;set;}

    public Owners Owner{get;set;}

    public Breeds Breed {get;set;}

    public ICollection<History> MedicalHistory{get;set;}
    [Timestamp]
     public DateTime CreatedDate{get;set;}=DateTime.Now;

     public string S_DOB {
    get{
        if(DOB!=null){
            return DOB.ToString("yyy-MM-dd");
        }
        return "";
    }}

}