namespace UCondoAccountTree.Domain.AggregatesModels.AccountTypes;

using Accounts;

public class AccountTypeId : TypedIdValueBase
{
    public AccountTypeId(Guid value) : base(value) { }
    public static AccountId Empty => new(Guid.Empty);
}
