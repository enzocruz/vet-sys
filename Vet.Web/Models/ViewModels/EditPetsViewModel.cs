namespace Vet.Web.Models.ViewModels;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
public class EditPetsViewModel{

    [Required]
    public int Id { get; set; }
    [Required(ErrorMessage ="Name is required")]
    [MaxLength(100,ErrorMessage ="Name max lenght is only 100 characters")]
   
    public string Name { get; set; }
    [Required(ErrorMessage ="Breed is required")]
    public int BreedID{get;set;}
   [Required(ErrorMessage ="Sex is Required")]
    public Int16 Sex{get;set;}
    [Required(ErrorMessage ="Date of Birth is Required")]
    public DateTime DOB{get;set;}
    [Required(ErrorMessage ="Onwer is required")]
    public int OwnerID{get;set;}
    [Required(ErrorMessage ="Age is required")]
    public int Age{get;set;}
    [ValidateNever]
    public IEnumerable<Owners> Owners{get;set;}
    [ValidateNever]
    public IEnumerable<Breeds> Breeds {get;set;}
    
    public string S_DOB {
    get{
        if(DOB!=null){
            return DOB.ToString("yyy-MM-dd");
        }
        return "";
    }}
   
}