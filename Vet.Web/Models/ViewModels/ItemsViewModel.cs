namespace Vet.Web.Models.ViewModels;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
public class ItemsViewModel{
    public int Id{get;set;}
    [Required]
    [MaxLength(100,ErrorMessage ="Name must be less than 100 character long.")]
    public string Name { get; set; }
    [Required]
   
    public Double Price{get;set;}
    public string? Description{get;set;}
    [Required]
    public int TypeID{get;set;}
    [ValidateNever]
   public List<ItemType> Types{get;set;}
}