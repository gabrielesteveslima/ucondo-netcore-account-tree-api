namespace UCondoAccountTree.Application.Account.Queries.GetNextCode;

using Domain.AggregatesModels.Accounts;

public class GetNextAccountCodeQuery : IQuery<CodeSuggestionDto>
{
    public GetNextAccountCodeQuery(AccountId parentAccountId)
    {
        ParentAccountId = parentAccountId;
    }

    public AccountId ParentAccountId { get; set; }
}
