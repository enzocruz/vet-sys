namespace Vet.Web.Models;
using System.ComponentModel.DataAnnotations;

public class Appointment{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name{get;set;}
    [Required]
    public DateTime AppointmentDate{get;set;}
 
    public string Reason{get;set;}
    [Timestamp]
     public DateTime CreatedDate{get;set;}=DateTime.Now;
    
}