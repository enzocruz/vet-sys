using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
namespace Vet.Web.Models.ViewModels;

public class MedRecordViewModel{
   public Pets Pet{get;set;}
   public History History{get;set;}
}