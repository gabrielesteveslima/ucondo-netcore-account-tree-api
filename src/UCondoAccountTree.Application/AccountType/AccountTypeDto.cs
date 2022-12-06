namespace UCondoAccountTree.Application.AccountType;

public class AccountTypeDto
{
    public AccountTypeDto(Guid accountTypeId, string name)
    {
        AccountTypeId = accountTypeId;
        Name = name;
    }

    public Guid AccountTypeId { get; set; }
    public string Name { get; set; }
}
