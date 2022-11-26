namespace Vet.Web.Models;
using System.ComponentModel.DataAnnotations;
public class Owners{
    [Key]
    public int Id { get; set; }
   [MaxLength(100)]
    public string Name{get;set;}
   [MaxLength(255)]
    public string Address{get;set;}
   [MaxLength(20)]
    public string ContactNumber{get;set;}
    [Timestamp]
     public DateTime CreatedDate{get;set;}=DateTime.Now;

     public List<Pets> Pets{get;set;}
}