namespace UCondoAccountTree.WebAPI.Features.v1;

using Application.Account;
using Application.Account.Commands;
using Application.Account.Queries;
using Application.Account.Queries.GetDetailsAccount;
using Application.Account.Queries.GetListAccounts;
using Application.Account.Queries.GetNextCode;
using Configuration.ProblemDetails.Helpers;
using Domain.AggregatesModels.Accounts;
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
    [ProducesResponseType(typeof(AccountDto), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAccounts([FromQuery] PagedAccountsQueryParams accountsQueryParams)
    {
        var accountsList = await _mediator.Send(new GetAccountsQuery(accountsQueryParams.PageNumber, accountsQueryParams.PageSize));
        return Ok(accountsList);
    }

    [HttpGet("{accountId:guid}/next-code")]
    [ProducesResponseType(typeof(CodeSuggestionDto), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetNextAccountCode(Guid accountId)
    {
        var codeSuggestion = await _mediator.Send(new GetNextAccountCodeQuery(new AccountId(accountId)));
        return Ok(codeSuggestion);
    }
    
    [HttpGet("{accountId:guid}")]
    [ProducesResponseType(typeof(CodeSuggestionDto), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAccountDetails(Guid accountId)
    {
        var codeSuggestion = await _mediator.Send(new GetAccountDetailsQuery(new AccountId(accountId)));
        return Ok(codeSuggestion);
    }
}
