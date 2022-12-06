namespace UCondoAccountTree.Application.Account;

public class AccountDto
{
    public AccountDto(string name, string accountCode, Guid accountTypeId, Guid parentAccountId, bool acceptBilling)
    {
        Name = name;
        AccountCode = accountCode;
        AccountTypeId = accountTypeId;
        ParentAccountId = parentAccountId;
        AcceptBilling = acceptBilling;
    }

    public AccountDto(string name, string accountCode)
    {
        Name = name;
        AccountCode = accountCode;
    }

    public string Name { get; }
    public string AccountCode { get; }
    public Guid AccountTypeId { get; }
    public Guid ParentAccountId { get; }
    public bool AcceptBilling { get; }
}
