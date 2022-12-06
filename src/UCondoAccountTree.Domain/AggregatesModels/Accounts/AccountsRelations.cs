namespace UCondoAccountTree.Domain.AggregatesModels.Accounts;

public class AccountsRelations : Entity
{
    //ef-core
    public AccountsRelations()
    {
    }

    public AccountsRelations(AccountId parentAccountId, AccountId childAccountId)
    {
        ParentAccountId = parentAccountId;
        ChildAccountId = childAccountId;
        CreateAt = DateTime.Now;
    }

    public AccountId ParentAccountId { get; set; }
    public AccountId ChildAccountId { get; set; }
}
