namespace UCondoAccountTree.Domain.AggregatesModels.AccountTypes;

using Accounts;
using System.ComponentModel.DataAnnotations;

public class AccountType : Entity, IAggregateRoot
{
    //ef-core
    public AccountType()
    {
    }

    private AccountType(string name)
    {
        AccountTypeId = new AccountTypeId(Guid.NewGuid());
        Name = name;
    }

    [Key] public AccountTypeId AccountTypeId { get; }

    public string Name { get; }
    public AccountId AccountId { get; set; }
    public ICollection<Account> AccountsRef { get; set; }

    public static AccountType Create(string name)
    {
        return new AccountType(name);
    }
}
