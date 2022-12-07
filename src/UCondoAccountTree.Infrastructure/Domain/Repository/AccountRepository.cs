namespace UCondoAccountTree.Infrastructure.Domain.Repository;

using Database;
using Microsoft.EntityFrameworkCore;
using UCondoAccountTree.Domain.AggregatesModels.Accounts;

public class AccountRepository : IAccountRepository
{
    private readonly UCondoAccountTreeContext _context;

    public AccountRepository(UCondoAccountTreeContext uCondoAccountTreeContext)
    {
        _context = uCondoAccountTreeContext ?? throw new ArgumentNullException(nameof(uCondoAccountTreeContext));
    }

    public async Task AddAsync(Account account)
    {
        await _context.Accounts.AddAsync(account);
    }

    public async Task<Account> GetByIdAsync(AccountId accountId)
    {
        return await _context.Accounts.SingleAsync(x => x.AccountId == accountId);
    }

    public async Task<List<Account>> GetByListIdAsync(List<AccountId> accountIds)
    {
        return await _context.Accounts.Where(x => accountIds.Contains(x.AccountId)).ToListAsync();
    }

    public bool CheckAccountCodeExists(string accountCode)
    {
        return _context.Accounts.Any(x => x.AccountCode.Value == accountCode);
    }

    public async Task<List<Account>> GetAllAsync(int skip, int pageSize)
    {
        return await _context.Accounts.Skip(skip).Take(pageSize)
            .ToListAsync();
    }

    public async Task<double> CountAccountsAsync()
    {
        return await _context.Accounts.CountAsync();
    }

    public async Task<Account> GetLastRelationIfExistsOrParentAccount(AccountId parentAccountId)
    {
        var parentAccount = await GetByIdAsync(parentAccountId);

        var getLastAccountRelation = parentAccount.AccountsRelations.MaxBy(x => x.CreateAt);

        if (getLastAccountRelation != null)
        {
            return await GetByIdAsync(getLastAccountRelation.ChildAccountId);
        }

        return parentAccount;
    }
}
