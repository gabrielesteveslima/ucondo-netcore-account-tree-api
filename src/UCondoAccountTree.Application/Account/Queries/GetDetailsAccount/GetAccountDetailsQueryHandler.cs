namespace UCondoAccountTree.Application.Account.Queries.GetDetailsAccount;

using Domain.AggregatesModels.Accounts;

public class GetAccountDetailsQueryHandler : IQueryHandler<GetAccountDetailsQuery, AccountDetailsDto>
{
    private readonly IAccountRepository _accountRepository;

    public GetAccountDetailsQueryHandler(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public async Task<AccountDetailsDto> Handle(GetAccountDetailsQuery request, CancellationToken cancellationToken)
    {
        var account = await _accountRepository.GetByIdAsync(request.AccountId);

        var result = new AccountDetailsDto { Name = account.Name, AccountCode = account.AccountCode.Value, AccountId = account.AccountId.Value };

        var accountRelations = await _accountRepository.GetByListIdAsync(account.AccountsRelations.Select(x => x.ChildAccountId).ToList());
        foreach (var accountRelation in accountRelations)
        {
            result.ChildAccounts.Add(new AccountRelationDto { Name = accountRelation.Name, AccountCode = accountRelation.AccountCode.Value, AccountId = account.AccountId.Value });
        }

        return result;
    }
}
