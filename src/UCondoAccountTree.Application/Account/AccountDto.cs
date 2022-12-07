namespace UCondoAccountTree.Application.Account;

public class AccountDto
{
    public string Name { get; set; }
    public string AccountCode { get; set; }
    public Guid AccountTypeId { get; set; }
    public Guid ParentAccountId { get; set; }
    public bool AcceptBilling { get; set; }
}
