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

        var result = new AccountsPagedList { TotalAccounts = totalAccounts, TotalPages = totalPages };

        foreach (var account in accounts)
        {
            var item = new AccountsPagedListData { Name = account.Name, AccountId = account.AccountId.Value };

            foreach (var accountsRelation in account.AccountsRelations)
            {
                item.ChildAccounts.Add(accountsRelation.ChildAccountId.Value);
            }
            
            result.Accounts.Add(item);
        }

        return result;
    }
}
