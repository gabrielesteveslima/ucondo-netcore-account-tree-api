namespace UCondoAccountTree.Application.Account.Commands;

using FluentValidation;

public class CreateNewAccountCommandValidator : AbstractValidator<CreateNewAccountCommand>
{
    public CreateNewAccountCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("'Name' account is required");
        RuleFor(x => x.AccountCode).NotEmpty().WithMessage("'AccountCode' account is required")
            .Matches("^[1-999](.[1-999])*$").WithMessage("'AccountCode' not matches with partters");
        RuleFor(x => x.AccountTypeId).NotEmpty().WithMessage("'AccountCode' account is required");
    }
}
