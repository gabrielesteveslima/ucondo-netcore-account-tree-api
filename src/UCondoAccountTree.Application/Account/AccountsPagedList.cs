namespace UCondoAccountTree.Application.Account;

public class AccountsPagedList
{
    public AccountsPagedList()
    {
        Accounts = new List<AccountsPagedListData>();
    }

    public List<AccountsPagedListData> Accounts { get; set; }
    public double TotalAccounts { get; set; }
    public double TotalPages { get; set; }
}

public class AccountsPagedListData
{
    public AccountsPagedListData()
    {
        ChildAccounts = new List<Guid>();
    }

    public Guid AccountId { get; set; }
    public List<Guid> ChildAccounts { get; set; }
    public string Name { get; set; }
}
