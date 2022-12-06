namespace UCondoAccountTree.Application.AccountType.Commands;

public class CreateNewAccountTypeCommand : CommandBase<AccountTypeDto>
{
    public CreateNewAccountTypeCommand(string name)
    {
        Name = name;
    }

    public string Name { get; set; }
}
