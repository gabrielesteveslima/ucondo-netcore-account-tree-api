namespace UCondoAccountTree.Domain.AggregatesModels.Accounts;

public class AccountCode : ValueObject
{
    //ef-core
    public AccountCode()
    {
    }

    private AccountCode(string accountCode)
    {
        CheckRule(new AccountCodeMatchesWithStandard(accountCode));
        Value = accountCode;
    }

    public string Value { get; }

    public static AccountCode Create(string accountCode)
    {
        return new AccountCode(accountCode);
    }

    public static string GetNextCode(Account lastAccountOfParent)
    {
        var codesParts = lastAccountOfParent.AccountCode.Value.Split(".").Reverse().ToArray();
        var nextCode = "";
        var sugestCode = false;

        const int maxValue = 999;

        foreach (var codePart in codesParts)
        {
            var code = Convert.ToInt32(codePart);

            if (code + 1 <= maxValue)
            {
                if (!sugestCode)
                {
                    nextCode += $"{code + 1}";
                }
                else
                {
                    nextCode += $".{code}";
                }

                sugestCode = true;
            }
        }

        return string.Join(".", nextCode.Split(".").Reverse().ToArray());
    }
}
