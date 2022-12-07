namespace UCondoAccountTree.Application.Account.Commands;

public class CreateNewAccountCommand : CommandBase<AccountDto>
{
    public CreateNewAccountCommand(string name, string accountCode, Guid accountTypeId, Guid parentAccountId, bool acceptBilling)
    {
        Name = name;
        AccountCode = accountCode;
        AccountTypeId = accountTypeId;
        ParentAccountId = parentAccountId;
        AcceptBilling = acceptBilling;
    }

    public string Name { get; }
    public string AccountCode { get; }
    public Guid AccountTypeId { get; }
    public Guid ParentAccountId { get; }
    public bool AcceptBilling { get; }
}
