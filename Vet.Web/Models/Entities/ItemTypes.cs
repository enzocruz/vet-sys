namespace Vet.Web.Models;
using System.ComponentModel.DataAnnotations;
public class ItemType{
    [Key]
    public int Id { get; set; }
    [MaxLength(100)]
    public string Name{get;set;}
     [MaxLength(255)]
    public string? Description { get; set; }
    [Required(ErrorMessage ="Item type is required")]
    

    [Timestamp]
    public DateTime CreatedDate{get;set;}=DateTime.Now;
    
    public ICollection<Items>Items{get;set;}

    
}