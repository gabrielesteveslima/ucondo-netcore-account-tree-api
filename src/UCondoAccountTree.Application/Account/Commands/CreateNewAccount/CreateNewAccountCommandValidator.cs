namespace UCondoAccountTree.Application.Account.Commands.CreateNewAccount;

using FluentValidation;

public class CreateNewAccountCommandValidator : AbstractValidator<CreateNewAccountCommand>
{
    public CreateNewAccountCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("'Name' account is required");
        RuleFor(x => x.AccountCode).NotEmpty().WithMessage("'AccountCode' account is required");
        RuleFor(x => x.AccountTypeId).NotEmpty().WithMessage("'AccountCode' account is required");
    }
}
