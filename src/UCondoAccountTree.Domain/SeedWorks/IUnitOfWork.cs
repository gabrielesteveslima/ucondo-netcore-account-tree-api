namespace UCondoAccountTree.Domain.SeedWorks;

public interface IUnitOfWork
{
    Task<int> CommitAsync(CancellationToken cancellationToken = default);
}
