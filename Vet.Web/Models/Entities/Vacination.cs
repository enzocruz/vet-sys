namespace Vet.Web.Models;
using System.ComponentModel.DataAnnotations;
public class Vacination{

    [Key]
    public int Id { get; set; }
    [Required]
    public int PetID { get; set; }
    [Required]
    public int HistoryID{get;set;}
    [Required]
    public int ItemID{get;set;}

    public History History{get;set;}

    public Pets Pet{get;set;}
    [Timestamp]
    public DateTime CreatedDate{get;set;}=DateTime.Now;




}