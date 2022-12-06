namespace UCondoAccountTree.Application.Account.Queries;

using Commands;

public class AccountDtoList
{
    public AccountDto ParentAccount { get; set; }
    public IEnumerable<AccountDto> ChildAccounts { get; set; }
}
