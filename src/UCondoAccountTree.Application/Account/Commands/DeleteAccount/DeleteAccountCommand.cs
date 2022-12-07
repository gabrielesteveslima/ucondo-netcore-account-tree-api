namespace UCondoAccountTree.Application.Account.Commands.DeleteAccount;

using Domain.AggregatesModels.Accounts;

public class DeleteAccountCommand : CommandBase<AccountId>
{
    public AccountId AccountId { get; set; }

    public DeleteAccountCommand(AccountId accountId)
    {
        AccountId = accountId;
    }
}
