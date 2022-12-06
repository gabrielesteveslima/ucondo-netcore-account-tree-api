namespace UCondoAccountTree.Application.AccountType.Commands;

using Domain.AggregatesModels.AccountTypes;
using Domain.SeedWorks;

public class CreateNewAccountTypeCommandHandler : ICommandHandler<CreateNewAccountTypeCommand, AccountTypeDto>
{
    private readonly IAccountTypeRepository _accountTypeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateNewAccountTypeCommandHandler(IAccountTypeRepository accountTypeRepository, IUnitOfWork unitOfWork)
    {
        _accountTypeRepository = accountTypeRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<AccountTypeDto> Handle(CreateNewAccountTypeCommand request, CancellationToken cancellationToken)
    {
        var accountType = AccountType.Create(request.Name);

        await _accountTypeRepository.AddAsync(accountType);
        await _unitOfWork.CommitAsync(cancellationToken);

        return new AccountTypeDto(accountType.AccountTypeId.Value, accountType.Name);
    }
}
