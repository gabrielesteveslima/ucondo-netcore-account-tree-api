namespace UCondoAccountTree.Infrastructure.Domain;

using Database;

public class UnitOfWork : IUnitOfWork
{
    private readonly UCondoAccountTreeContext _accountTreeContext;

    public UnitOfWork(UCondoAccountTreeContext accountTreeContext)
    {
        _accountTreeContext = accountTreeContext;
    }

    public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
    {
        return await _accountTreeContext.SaveChangesAsync(cancellationToken);
    }
}
