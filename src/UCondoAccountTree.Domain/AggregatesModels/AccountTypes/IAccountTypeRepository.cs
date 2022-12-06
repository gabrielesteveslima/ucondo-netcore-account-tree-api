namespace UCondoAccountTree.Domain.AggregatesModels.Accounts;

public interface IAccountTypeRepository
{
    Task<AccountType> GetByIdAsync(TypedId id);
    Task AddAsync(AccountType accountType);
    Task UpdateAsync(AccountType accountType);
    void RemoveAsync(TypedId id);
}
