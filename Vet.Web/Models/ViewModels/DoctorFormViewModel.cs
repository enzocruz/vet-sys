using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace Vet.Web.Models.ViewModels;

public class DoctorFormViewModel{
    [Required]
    [MaxLength(50,ErrorMessage ="Name must be less than 50 characters long.")]
    public string Name { get; set; }
    [Required]
    [MaxLength(255,ErrorMessage ="License must be less than 255 characters long.")]
    public string License{get;set;}

    [Required]
    [MaxLength(255,ErrorMessage ="Address must be less than 255 characters")]
    public string Address { get; set; }
    [Required]
    [MaxLength(20,ErrorMessage ="Contact number is only 20 characters max.")]
    public string ContactNumber { get; set; }
}