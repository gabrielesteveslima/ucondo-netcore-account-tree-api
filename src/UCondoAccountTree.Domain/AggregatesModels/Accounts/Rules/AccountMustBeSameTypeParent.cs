namespace UCondoAccountTree.Domain.AggregatesModels.Accounts.Rules;

using AccountTypes;

public class AccountMustBeSameTypeParent : IBusinessRule
{
    private readonly AccountType _accountType;
    private readonly Account _parentAccount;

    public AccountMustBeSameTypeParent(Account parentAccount, AccountType accountType)
    {
        _parentAccount = parentAccount;
        _accountType = accountType;
    }

    public bool IsBroken()
    {
        return _parentAccount.AccountTypeRef != _accountType;
    }

    public string Message => "Account Type must be same parent";
}
