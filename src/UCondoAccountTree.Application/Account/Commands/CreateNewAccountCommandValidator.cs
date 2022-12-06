namespace UCondoAccountTree.Application.Account.Commands;

using FluentValidation;

public class AccountDtoValidator : AbstractValidator<CreateNewAccountCommand>
{
    public AccountDtoValidator()
    {
        RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("'Name' account is required");
        RuleFor(x => x.AcceptBilling).NotNull().NotEmpty().WithMessage("'AcceptBilling' account is required");
        RuleFor(x => x.AccountCode).NotNull().NotEmpty().WithMessage("'AccountCode' account is required");
        RuleFor(x => x.AccountTypeId).NotNull().NotEmpty().WithMessage("'AccountCode' account is required");
        RuleFor(x => x.ParentAccountId).NotEmpty().WithMessage("'ParentAccountId' account is required");
    }
}
