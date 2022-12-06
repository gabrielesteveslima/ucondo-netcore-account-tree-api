﻿namespace UCondoAccountTree.Application.Account.Commands;

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

        // create a parent
        if (request.ParentAccountId == Guid.Empty)
        {
            account = Account.Create(request.AccountCode, request.Name, accountTypeId, request.AcceptBilling);
        }
        else
        {
            var parentAccount = await _accountRepository.GetByIdAsync(new AccountId(request.ParentAccountId));
            var accountType = await _accountTypeRepository.GetByIdAsync(new AccountTypeId(request.AccountTypeId));
            account = Account.CreateChildAccount(parentAccount, request.AccountCode, request.Name, accountType, request.AcceptBilling);
        }

        await _accountRepository.AddAsync(account);
        await _unitOfWork.CommitAsync(cancellationToken);

        return new AccountDto(account.Name, account.AccountCode.Value, account.AccountTypeId.Value, request.ParentAccountId, account.AcceptBilling);
    }
}
