using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
namespace Vet.Web.Models.ViewModels;

public class VacHistoryViewModel{
   public Pets Pet{get;set;}
   public List<Vacination> Vaccination{get;set;}
}