namespace UCondoAccountTree.Infrastructure.Domain.Repository;

using Microsoft.EntityFrameworkCore;
using UCondoAccountTree.Domain.AggregatesModels.Accounts;
using UCondoAccountTree.Infrastructure.Database;

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

    public async Task<List<Account>> GetAllAsync()
    {
        return await _context.Accounts
            .ToListAsync();
    }
}
