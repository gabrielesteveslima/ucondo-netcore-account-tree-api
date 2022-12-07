namespace UCondoAccountTree.Application.Account.Queries.GetNextCode;

using Domain.AggregatesModels.Accounts;

public class GetNextAccountCodeQueryHandler : IQueryHandler<GetNextAccountCodeQuery, CodeSuggestionDto>
{
    private readonly IAccountRepository _accountRepository;

    public GetNextAccountCodeQueryHandler(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public async Task<CodeSuggestionDto> Handle(GetNextAccountCodeQuery request, CancellationToken cancellationToken)
    {
        var acccount = await _accountRepository.GetLastRelationIfExistsOrParentAccount(request.ParentAccountId);
        return new CodeSuggestionDto { CodeSuggestion = AccountCode.GetNextCode(acccount) };
    }
}
