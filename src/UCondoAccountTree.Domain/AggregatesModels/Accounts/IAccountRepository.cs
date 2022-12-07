namespace UCondoAccountTree.Domain.AggregatesModels.Accounts;

public interface IAccountRepository
{
    Task AddAsync(Account account);
    Task<Account> GetByIdAsync(AccountId accountId);
    bool CheckAccountCodeExists(string accountCode);
    Task<List<Account>> GetAllAsync();
    Task<Account> GetLastRelationIfExistsOrParentAccount(AccountId parentAccountId);
}