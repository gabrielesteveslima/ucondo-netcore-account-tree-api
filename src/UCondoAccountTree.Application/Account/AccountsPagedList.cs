namespace UCondoAccountTree.Application.Account;

public class AccountsPagedList
{
    public AccountsPagedList()
    {
        Accounts = new List<AccountDetailsDto>();
    }

    public List<AccountDetailsDto> Accounts { get; set; }
    public double TotalAccounts { get; set; }
    public double TotalPages { get; set; }
}

public class AccountDetailsDto
{
    public AccountDetailsDto()
    {
        ChildAccounts = new List<AccountRelationDto>();
    }

    public Guid AccountId { get; set; }
    public string AccountCode { get; set; }
    public List<AccountRelationDto> ChildAccounts { get; set; }
    public string Name { get; set; }
}

public class AccountRelationDto
{
    public Guid AccountId { get; set; }
    public string Name { get; set; }
    public string AccountCode { get; set; }
}
