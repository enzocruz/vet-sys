namespace Vet.Web.Models;

using System.ComponentModel.DataAnnotations;

public class Doctor{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(100)]
    public string Name{get;set;}
    [Required]
    [MaxLength(255)]
    public string Address{get;set;}
    [Required]
    [MaxLength(100)]
    public string License{get;set;}
    [Required]
    [MaxLength(20)]
    public string Number{get;set;}
    [Timestamp]
     public DateTime CreatedDate{get;set;}=DateTime.Now;
    
   
}