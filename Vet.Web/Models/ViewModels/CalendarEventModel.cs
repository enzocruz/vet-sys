namespace Vet.Web.Models.ViewModels;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
public class CalendarEventViewModel{
  
    public string start{get;set;}
    public string title{get;set;}
   
    public int ID{get;set;}
    public string backgroundColor{get;set;}="green";

    public string borderColor{get;set;}="blue";
    
    public string display{get;set;}="list-item";
}