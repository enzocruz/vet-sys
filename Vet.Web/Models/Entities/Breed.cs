namespace Vet.Web.Models;
using System.ComponentModel.DataAnnotations;
public class Breeds{
    [Key]
    public int Id { get; set; }

    [Required]
    public String Name{get;set;}

   // public Animal Type{get;set;}
   
    public int AnimalID{get;set;}
    
    public DateTime CreatedDate{get;set;}=DateTime.Now;
}