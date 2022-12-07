namespace UCondoAccountTree.Domain.AggregatesModels.Accounts.Rules;

using System.Text.RegularExpressions;

public class AccountCodeMatchesWithStandard : IBusinessRule
{
    private readonly string _accountCode;

    public AccountCodeMatchesWithStandard(string accountCode)
    {
        _accountCode = accountCode;
    }

    public string Message => "the entered code does not meet the standard";

    public bool IsBroken()
    {
        return !Regex.IsMatch(_accountCode.ToLower().Trim(),
            @"^[1-999](.[1-999])*$");
    }
}
