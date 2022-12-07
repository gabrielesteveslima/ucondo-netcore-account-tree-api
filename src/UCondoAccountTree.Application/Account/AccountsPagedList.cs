namespace UCondoAccountTree.Application.Account;

public class AccountsPagedList
{
    public IEnumerable<AccountsPagedListData> Accounts { get; set; }
    public double TotalAccounts { get; set; }
    public double TotalPages { get; set; }
}

public class AccountsPagedListData
{
    public Guid AccountId { get; set; }
    public string Name { get; set; }
    public List<AccountsPagedListData> ChildAccounts { get; set; }
}
