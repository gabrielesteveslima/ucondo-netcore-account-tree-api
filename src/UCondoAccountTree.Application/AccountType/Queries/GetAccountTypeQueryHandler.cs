namespace UCondoAccountTree.Application.AccountType.Queries;

using Domain.AggregatesModels.AccountTypes;

public class GetAccountTypeQueryHandler : IQueryHandler<GetAccountTypeQuery, List<AccountTypeDto>>
{
    private readonly IAccountTypeRepository _accountTypeRepository;

    public GetAccountTypeQueryHandler(IAccountTypeRepository accountTypeRepository)
    {
        _accountTypeRepository = accountTypeRepository;
    }

    public async Task<List<AccountTypeDto>> Handle(GetAccountTypeQuery request, CancellationToken cancellationToken)
    {
        var accountTypeList = await _accountTypeRepository.GetAllAsync();
        return accountTypeList.Select(accountType => new AccountTypeDto(accountType.AccountTypeId.Value, accountType.Name)).ToList();
    }
}
