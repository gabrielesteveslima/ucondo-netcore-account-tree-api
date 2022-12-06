namespace UCondoAccountTree.WebAPI.Features.v1;

using Application.Account;
using Application.Account.Commands;
using Application.Account.Queries;
using Configuration.ProblemDetails.Helpers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

[ApiController]
[ApiVersion("1")]
[Route("api/accounts")]
[Produces("application/json")]
[ServiceFilter(typeof(ProblemDetailsFilter))]
public class AccountController : ControllerBase
{
    private readonly IMediator _mediator;

    public AccountController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(typeof(AccountDto), (int)HttpStatusCode.Created)]
    public async Task<IActionResult> CreateNewAccount(AccountDto request)
    {
        var account = await _mediator.Send(new CreateNewAccountCommand(request.Name,
            request.AccountCode, request.AccountTypeId, request.ParentAccountId, request.AcceptBilling));

        return Ok(account);
    }

    [HttpGet]
    [ProducesResponseType(typeof(AccountDto), (int)HttpStatusCode.Created)]
    public async Task<IActionResult> GetAccounts()
    {
        var accountsList = await _mediator.Send(new GetAccountsQuery());
        return Ok(accountsList);
    }
}
