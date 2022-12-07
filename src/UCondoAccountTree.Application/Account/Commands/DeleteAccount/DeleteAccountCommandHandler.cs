namespace UCondoAccountTree.Application.Account.Commands.DeleteAccount;

using Configuration;
using Domain.AggregatesModels.Accounts;
using Domain.SeedWorks;

public class DeleteAccountCommandHandler : ICommandHandler<DeleteAccountCommand, AccountId>
{
    private readonly IAccountRepository _accountRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAccountCommandHandler(IAccountRepository accountRepository, IUnitOfWork unitOfWork)
    {
        _accountRepository = accountRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<AccountId> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
    {
        var account = await _accountRepository.GetByIdAsync(request.AccountId);

        if (account == null)
            throw new NotFoundException($"not found account with {request.AccountId.Value}");

        _accountRepository.DeleteAccount(account);
        await _unitOfWork.CommitAsync(cancellationToken);

        return account.AccountId;
    }
}
