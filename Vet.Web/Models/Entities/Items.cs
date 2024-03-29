namespace Vet.Web.Models;
using System.ComponentModel.DataAnnotations;
public class Items{
    [Key]
    public int Id { get; set; }
    [MaxLength(100)]
     public string Name{get;set;}
     [MaxLength(255)]
    public string? Description { get; set; }
    [Required(ErrorMessage ="Item type is required")]
    public int ItemTypeId{get;set;}
    [Required]
    public double Price{get;set;}

    [Timestamp]
    public DateTime CreatedDate{get;set;}=DateTime.Now;
   public ItemType Type{get;set;}

    
}