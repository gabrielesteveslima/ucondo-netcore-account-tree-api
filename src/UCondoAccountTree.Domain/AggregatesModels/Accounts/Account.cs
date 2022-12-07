namespace UCondoAccountTree.Domain.AggregatesModels.Accounts;

using AccountTypes;
using System.ComponentModel.DataAnnotations;

public class Account : Entity, IAggregateRoot
{
    //ef-core
    public Account()
    {
        AccountsRelations = new List<AccountsRelations>();
    }

    private Account(AccountId accountId, string name, string accountCode, AccountTypeId accountTypeId, bool acceptBilling)
    {
        AccountId = accountId;
        Name = name;
        AccountCode = AccountCode.Create(accountCode);
        AccountTypeId = accountTypeId;
        AcceptBilling = acceptBilling;
        CreateAt = DateTime.Now;
    }

    [Key] public AccountId AccountId { get; }

    public List<AccountsRelations> AccountsRelations { get; set; }
    public AccountCode AccountCode { get; }
    public AccountTypeId AccountTypeId { get; set; }
    public virtual AccountType AccountTypeRef { get; }
    public string Name { get; }
    public bool AcceptBilling { get; }

    public static Account CreateChildAccount(IAccountRepository accountRepository, Account parentAccount, string accountCode, string name, AccountType accountType, bool acceptBilling)
    {
        CheckRule(new AccountCodeMustBeUnique(accountRepository, accountCode));
        CheckRule(new AccountWithBillingCannotParent(parentAccount));
        CheckRule(new AccountMustBeSameTypeParent(parentAccount, accountType));

        var childAccountId = new AccountId(Guid.NewGuid());
        var relationAccounts = new AccountsRelations(parentAccount.AccountId, childAccountId);
        parentAccount.AddRelation(relationAccounts);

        return new Account(childAccountId, name, accountCode, accountType.AccountTypeId, acceptBilling);
    }

    public static Account Create(IAccountRepository accountRepository, string accountCode, string name, AccountTypeId accountType, bool acceptBilling)
    {
        CheckRule(new AccountCodeMustBeUnique(accountRepository, accountCode));
        
        var parentAccountId = new AccountId(Guid.NewGuid());
        return new Account(parentAccountId, name, accountCode, accountType, acceptBilling);
    }

    public void AddRelation(AccountsRelations accountsRelations)
    {
        AccountsRelations.Add(accountsRelations);
    }
}
