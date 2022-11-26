namespace Vet.Web.Models.ViewModels;
public class PageViewModel{
    public string PageAction{get; private set;}
    public string PageController{get;private set;}
    public string Search{get;set;}
    public Pager Pager{get; private set;}

    public PageViewModel(){

    }
    public PageViewModel(Pager pager,string PageAction,string PageController){
        this.PageAction=PageAction;
        this.PageController=PageController;
        this.Pager=pager;
        this.Search="";
    }
    public PageViewModel(Pager pager,string PageAction,string PageController,string Search){
        this.PageAction=PageAction;
        this.PageController=PageController;
        this.Pager=pager;
        this.Search=Search;
    }
}