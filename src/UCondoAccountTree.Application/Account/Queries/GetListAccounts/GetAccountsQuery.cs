namespace UCondoAccountTree.Application.Account.Queries.GetListAccounts;

public class GetAccountsQuery : IQuery<AccountsPagedList>
{
    public GetAccountsQuery(int pageNumber, int pageSize)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
    }

    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}
