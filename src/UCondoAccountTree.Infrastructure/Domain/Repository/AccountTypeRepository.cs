namespace UCondoAccountTree.Infrastructure.Domain.Repository;

using Database;
using Microsoft.EntityFrameworkCore;
using UCondoAccountTree.Domain.AggregatesModels.AccountTypes;

public class AccountTypeRepository : IAccountTypeRepository
{
    private readonly UCondoAccountTreeContext _context;

    public AccountTypeRepository(UCondoAccountTreeContext context)
    {
        _context = context;
    }

    public Task<AccountType> GetByIdAsync(AccountTypeId accountTypeId)
    {
        return _context.AccountTypes.SingleAsync(x => x.AccountTypeId == accountTypeId);
    }

    public async Task<List<AccountType>> GetAllAsync()
    {
        return await _context.AccountTypes.ToListAsync();
    }

    public async Task AddAsync(AccountType accountType)
    {
        await _context.AccountTypes.AddAsync(accountType);
    }
}
