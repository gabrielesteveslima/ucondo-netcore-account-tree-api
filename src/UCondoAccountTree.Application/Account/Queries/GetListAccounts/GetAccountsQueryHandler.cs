namespace UCondoAccountTree.Application.Account.Queries.GetListAccounts;

using UCondoAccountTree.Domain.AggregatesModels.Accounts;

public class GetAccountsQueryHandler : IQueryHandler<GetAccountsQuery, AccountsPagedList>
{
    private readonly IAccountRepository _accountRepository;

    public GetAccountsQueryHandler(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public async Task<AccountsPagedList> Handle(GetAccountsQuery request, CancellationToken cancellationToken)
    {
        var totalAccounts = await _accountRepository.CountAccountsAsync();
        var totalPages = Math.Ceiling(totalAccounts / request.PageSize);
        var skip = (request.PageNumber - 1) * request.PageSize;

        var accounts = await _accountRepository.GetAllAsync(skip, request.PageSize);

        return new AccountsPagedList { TotalAccounts = totalAccounts, TotalPages = totalPages, Accounts = accounts.Select(x => new AccountsPagedListData { Name = x.Name, AccountId = x.AccountId.Value }) };
    }
}
