namespace UCondoAccountTree.Application.AccountType.Commands;

using FluentValidation;

public class CreateNewAccountTypeCommandValidator : AbstractValidator<CreateNewAccountTypeCommand>
{
    public CreateNewAccountTypeCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("'Name' is requiried");
    }
}
