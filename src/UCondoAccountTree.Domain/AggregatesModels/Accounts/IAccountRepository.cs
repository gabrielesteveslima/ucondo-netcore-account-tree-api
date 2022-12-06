namespace UCondoAccountTree.Domain.AggregatesModels.Accounts;

public interface IAccountRepository
{
    Task AddAsync(Account account);
    Task<Account> GetByIdAsync(AccountId accountId);
    Task<List<Account>> GetAllAsync();
}
