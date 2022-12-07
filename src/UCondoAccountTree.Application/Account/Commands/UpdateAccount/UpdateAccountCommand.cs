namespace UCondoAccountTree.Application.Account.Commands.UpdateAccount;

public class UpdateAccountCommand : CommandBase<AccountDto>
{
    public UpdateAccountCommand(string name, string accountCode, Guid accountTypeId, Guid parentAccountId, bool acceptBilling)
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
