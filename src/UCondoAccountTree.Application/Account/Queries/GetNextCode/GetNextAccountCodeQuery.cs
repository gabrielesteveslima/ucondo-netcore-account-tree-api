namespace UCondoAccountTree.Application.Account.Queries.GetNextCode;

using Domain.AggregatesModels.Accounts;

public class GetNextAccountCodeQuery : IQuery<CodeSuggestionDto>
{
    public AccountId ParentAccountId { get; set; }

    public GetNextAccountCodeQuery(AccountId parentAccountId)
    {
        ParentAccountId = parentAccountId;
    }
}
