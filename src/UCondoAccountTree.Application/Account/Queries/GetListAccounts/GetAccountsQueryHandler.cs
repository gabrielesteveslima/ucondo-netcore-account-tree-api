namespace UCondoAccountTree.Application.Account.Queries.GetListAccounts;

using UCondoAccountTree.Domain.AggregatesModels.Accounts;

public class GetAccountsQueryHandler : IQueryHandler<GetAccountsQuery, AccountDtoList>
{
    private readonly IAccountRepository _accountRepository;

    public GetAccountsQueryHandler(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    //TODO> fix child accounts
    public async Task<AccountDtoList> Handle(GetAccountsQuery request, CancellationToken cancellationToken)
    {
        var allAccounts = await _accountRepository.GetAllAsync();
        var responseList = new AccountDtoList();

        foreach (var account in allAccounts)
        {
            foreach (var childOfAccount in account.AccountsRelations)
            {
                responseList.Data.Add(new AccountDtoListData { ParentAccount = new AccountDto { Name = account.Name, AccountCode = account.AccountCode.Value }, ChildAccounts = allAccounts.Where(x => x.AccountsRelations.Any(y => y.ParentAccountId == account.AccountId)).Select(x => new AccountDto { Name = x.Name, AccountCode = x.AccountCode.Value }) });
            }
        }

        return responseList;
    }
}
