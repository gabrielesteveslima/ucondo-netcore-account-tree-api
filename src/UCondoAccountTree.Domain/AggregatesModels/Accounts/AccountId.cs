namespace UCondoAccountTree.Domain.AggregatesModels.Accounts;

public class AccountId : TypedIdValueBase
{
    public AccountId(Guid value) : base(value) { }
    public static AccountId Empty => new(Guid.Empty);
}
