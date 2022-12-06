namespace UCondoAccountTree.Application.Account.Commands;

using Domain.AggregatesModels.Accounts;

public class AccountDto
{
    public string Name { get; }
    public string AccountCode { get; }
    public Guid AccountTypeId { get; }
    public Guid? ParentAccountId { get; }
    public bool AcceptBilling { get; }

    public AccountDto(string name, string accountCode, Guid accountTypeId, Guid? parentAccountId, bool acceptBilling)
    {
        Name = name;
        AccountCode = accountCode;
        AccountTypeId = accountTypeId;
        ParentAccountId = parentAccountId;
        AcceptBilling = acceptBilling;
    }
}
