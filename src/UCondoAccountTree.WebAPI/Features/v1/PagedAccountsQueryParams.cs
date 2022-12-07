namespace UCondoAccountTree.WebAPI.Features.v1;

using Microsoft.AspNetCore.Mvc.ModelBinding;

public class PagedAccountsQueryParams
{
    [BindRequired] public int PageNumber { get; set; }
    [BindRequired] public int PageSize { get; set; }
}
