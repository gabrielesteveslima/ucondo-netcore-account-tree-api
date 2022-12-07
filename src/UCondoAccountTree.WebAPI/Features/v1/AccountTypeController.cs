namespace UCondoAccountTree.WebAPI.Features.v1;

using Application.AccountType;
using Application.AccountType.Commands;
using Application.AccountType.Queries;
using Configuration.ProblemDetails.Helpers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

[ApiController]
[ApiVersion("1")]
[Route("api/account-types")]
[Produces("application/json")]
[ServiceFilter(typeof(ProblemDetailsFilter))]
public class AccountTypeController : ControllerBase
{
    private readonly IMediator _mediator;

    public AccountTypeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(typeof(AccountTypeDto), (int)HttpStatusCode.Created)]
    public async Task<IActionResult> CreateNewAccountType(AccountTypeDto request)
    {
        var accountType = await _mediator.Send(new CreateNewAccountTypeCommand(request.Name));
        return Created(accountType.AccountTypeId.ToString(), accountType);
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<AccountTypeDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAccountsTypes()
    {
        var accountsTypeList = await _mediator.Send(new GetAccountTypeQuery());
        return Ok(accountsTypeList);
    }
}
