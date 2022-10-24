namespace Vet.Web.Models;
using System.ComponentModel.DataAnnotations;
public class Animal{

    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(100)]
    public String Name{get;set;}

    public String? Description{get;set;}
    [Timestamp]
     public DateTime CreatedDate{get;set;}=DateTime.Now;

     public ICollection<Breeds> Breeds{get;set;}
}