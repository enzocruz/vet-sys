namespace Vet.Web.Models;
using System.ComponentModel.DataAnnotations;

public class Appointment{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(30,ErrorMessage ="Name is too loog, only 30 characters are allowed.")]
    public string Name{get;set;}
    [Required]
    public DateTime AppointmentDate{get;set;}
    [Required]
    [MaxLength(255,ErrorMessage ="Reason is to long, 255 is the max lenght.")]
    public string Reason{get;set;}
    [Timestamp]
     public DateTime CreatedDate{get;set;}=DateTime.Now;
    
}