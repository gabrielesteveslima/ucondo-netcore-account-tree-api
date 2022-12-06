namespace UCondoAccountTree.Domain.AggregatesModels.Accounts.Rules;

public class AccountWithBillingCannotParent : IBusinessRule
{
    private readonly Account _parentAccount;

    public AccountWithBillingCannotParent(Account parentAccount)
    {
        _parentAccount = parentAccount;
    }

    public bool IsBroken()
    {
        return _parentAccount.AcceptBilling;
    }

    public string Message => "Account with billing cannot parent";
}
