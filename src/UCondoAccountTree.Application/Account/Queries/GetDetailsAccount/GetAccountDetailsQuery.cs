namespace UCondoAccountTree.Application.Account.Queries.GetDetailsAccount;

using Domain.AggregatesModels.Accounts;

public class GetAccountDetailsQuery : IQuery<AccountDetailsDto>
{
    public AccountId AccountId { get; set; }

    public GetAccountDetailsQuery(AccountId accountId)
    {
        AccountId = accountId;
    }
}
