namespace Vet.Web.Models;
using System.ComponentModel.DataAnnotations;

public class Transactions{

    [Key]
    public  int Id { get; set; }

    [Required]
    public int ItemID{get;set;}

    [Required]
    public Int16 Type{get;set;}
    [Required]
    public int Count{get;set;}

    public double? Price{get;set;}    
    [Timestamp]
     public DateTime CreatedDate{get;set;}=DateTime.Now;

    public DateTime ExpirationDate{get;set;}

    public Items Item{get;set;}
    
}