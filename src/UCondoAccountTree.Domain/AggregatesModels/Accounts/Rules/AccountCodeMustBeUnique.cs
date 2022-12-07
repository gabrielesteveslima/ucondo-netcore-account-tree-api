namespace UCondoAccountTree.Domain.AggregatesModels.Accounts.Rules;

public class AccountCodeMustBeUnique : IBusinessRule
{
    private readonly string _accountCode;
    private readonly IAccountRepository _accountRepository;

    public AccountCodeMustBeUnique(IAccountRepository accountRepository, string accountCode)
    {
        _accountRepository = accountRepository;
        _accountCode = accountCode;
    }

    public bool IsBroken()
    {
        return _accountRepository.CheckAccountCodeExists(_accountCode);
    }

    public string Message => "Account Code already exists";
}
