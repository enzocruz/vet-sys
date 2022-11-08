namespace Vet.Web.Models.ViewModels;
public class PageViewModel{
    public string PageAction{get; private set;}
    public string PageController{get;private set;}

    public Pager Pager{get; private set;}

    public PageViewModel(){

    }
    public PageViewModel(Pager pager,string PageAction,string PageController){
        this.PageAction=PageAction;
        this.PageController=PageController;
        this.Pager=pager;
    }
}