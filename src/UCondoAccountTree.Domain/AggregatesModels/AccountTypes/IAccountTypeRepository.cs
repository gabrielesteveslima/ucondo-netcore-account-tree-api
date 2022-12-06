namespace UCondoAccountTree.Domain.AggregatesModels.AccountTypes;

public interface IAccountTypeRepository
{
    Task<AccountType> GetByIdAsync(AccountTypeId accountTypeId);
    Task<List<AccountType>> GetAllAsync();
    Task AddAsync(AccountType accountType);
}
