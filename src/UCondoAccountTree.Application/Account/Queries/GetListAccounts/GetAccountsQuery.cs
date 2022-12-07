namespace UCondoAccountTree.Application.Account.Queries.GetListAccounts;

public class GetAccountsQuery : IQuery<AccountsPagedList>
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    
    public GetAccountsQuery(int pageNumber, int pageSize)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
    }
}
