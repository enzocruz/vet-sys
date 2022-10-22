namespace Vet.Web.Models;
using System.ComponentModel.DataAnnotations;
public class Animal{

    [Key]
    public int Id { get; set; }
    [Required]
    public String Name{get;set;}

    public String? Description{get;set;}

     public DateTime CreatedDate{get;set;}=DateTime.Now;
}