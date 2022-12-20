namespace Vet.Web.Models;
using System.ComponentModel.DataAnnotations;
public class Prescription{

    [Key]
    public int Id { get; set; }
    [Required]
    public int PetID { get; set; }
    [Required]
    public int HistoryID{get;set;}
    [Required]
    public int ItemID{get;set;}
    [Required]
    [MaxLength(255)]
    public string Description {get;set;}
    public History History{get;set;}

    public Pets Pet{get;set;}
    
    [Timestamp]
    public DateTime CreatedDate{get;set;}=DateTime.Now;




}