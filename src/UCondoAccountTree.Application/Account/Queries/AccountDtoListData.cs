﻿namespace UCondoAccountTree.Application.Account.Queries;

public class AccountDtoListData
{
    public AccountDto ParentAccount { get; set; }
    public IEnumerable<AccountDto> ChildAccounts { get; set; }
}

public class AccountDtoList
{
    public List<AccountDtoListData> Data { get; set; }
}
