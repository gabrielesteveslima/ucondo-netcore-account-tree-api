namespace UCondoAccountTree.Application.Account.Commands.CreateNewAccount;

using Configuration;
using Domain.AggregatesModels.Accounts;
using Domain.AggregatesModels.AccountTypes;
using Domain.SeedWorks;

public class CreateNewAccountCommandHandler : ICommandHandler<CreateNewAccountCommand, AccountDto>
{
    private readonly IAccountRepository _accountRepository;
    private readonly IAccountTypeRepository _accountTypeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateNewAccountCommandHandler(IAccountRepository accountRepository, IAccountTypeRepository accountTypeRepository, IUnitOfWork unitOfWork)
    {
        _accountRepository = accountRepository;
        _accountTypeRepository = accountTypeRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<AccountDto> Handle(CreateNewAccountCommand request, CancellationToken cancellationToken)
    {
        var accountTypeId = new AccountTypeId(request.AccountTypeId);
        Account account;

        if (request.ParentAccountId == Guid.Empty)
        {
            account = Account.Create(_accountRepository, request.AccountCode, request.Name, accountTypeId, request.AcceptBilling);
        }
        else
        {
            var parentAccount = await _accountRepository.GetByIdAsync(new AccountId(request.ParentAccountId));

            if (parentAccount == null)
                throw new NotFoundException($"not found parent account with {request.ParentAccountId}");

            var accountType = await _accountTypeRepository.GetByIdAsync(new AccountTypeId(request.AccountTypeId));
            account = Account.CreateChildAccount(_accountRepository, parentAccount, request.AccountCode, request.Name, accountType, request.AcceptBilling);
        }

        await _accountRepository.AddAsync(account);
        await _unitOfWork.CommitAsync(cancellationToken);

        return new AccountDto
        {
            Name = account.Name,
            AcceptBilling = account.AcceptBilling,
            AccountCode = account.AccountCode.Value,
            AccountTypeId = account.AccountTypeId.Value,
            ParentAccountId = request.ParentAccountId
        };
    }
}
