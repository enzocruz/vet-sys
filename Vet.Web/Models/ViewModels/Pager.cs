public class Pager{
    public int CurrentPage { get; private set; }
    public int PageSize{get; private set;}
    public int TotalPages{get; private set;}

    public int ListCount{get;private set;}

    public int Endpage{get; private set;}

    public int StartPage{get; private set;}
    public int NextPage{get;private set;}

    public int PreviousPage{get;private set;}
    public Pager(){

    }

    public Pager(int ItemCount,int page,int pagesize=10){
        this.PageSize=pagesize;
        this.TotalPages=(int)Math.Ceiling((decimal)ItemCount/(decimal)PageSize);
        int currentpage=page;
        int startPage=currentpage-5;
        int endPage=currentpage+4;
        if(startPage<=0){
            endPage=endPage-(startPage-1);
            startPage=1;
        }

        if(endPage>TotalPages){
            endPage=TotalPages;
            if(endPage>10){
                startPage=endPage-9;
            }
        }
        this.Endpage=endPage;
        this.CurrentPage=currentpage;
        this.StartPage=startPage;
        this.ListCount=ItemCount;

        this.PreviousPage=currentpage-1;
        this.NextPage=currentpage+1;
       
        
    }
}