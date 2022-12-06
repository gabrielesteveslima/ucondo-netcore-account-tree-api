namespace UCondoAccountTree.Domain.AggregatesModels.Accounts;

public class AccountChilds : Entity
{
    //ef-core
    public AccountChilds()
    {
        
    }
    
    public AccountChilds(AccountId parentAccountId, AccountId childAccountId)
    {
        ParentAccountId = parentAccountId;
        ChildAccountId = childAccountId;
    }
    
    public AccountId ParentAccountId { get; set; }
    public AccountId ChildAccountId { get; set; }
}
