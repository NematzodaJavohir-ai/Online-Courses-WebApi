using System;

namespace Application.Results;


public class PagedResult<T>
{
  public IReadOnlyList<T> Items{get;}

  public int TotalCount{get;}
  public int Page{get;}
  public int PageSize{get;}

  private int TotalPages => (int)Math.Ceiling(TotalCount/(double)PageSize);
  private bool  HasNextPage => Page<TotalPages;
  private bool  HasPreviousPage => Page>1;

  private PagedResult(IReadOnlyList<T> items,int totalcount,int page,int pagesize)
    {
        Items=items;
        TotalCount=totalcount;
        Page=page;
        PageSize=pagesize;
    }

    public static PagedResult<T> Ok(IReadOnlyList<T> items,int totalcount,int page,int pagesize) => new (items ,totalcount, page,pagesize);

}
