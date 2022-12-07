using NSubstitute;
using UCondoAccountTree.Domain.AggregatesModels.AccountTypes;

namespace UCondoAccountTree.Domain.Tests;

[TestFixture]
public class AccountCodeDomainTests
{
    [TestCase("1.9.8", ExpectedResult = "1.9.9")]
    [TestCase("1.999", ExpectedResult = "2")]
    [TestCase("2.2", ExpectedResult = "2.3")]
    [TestCase("2.999.999.999", ExpectedResult = "3")]
    [TestCase("1", ExpectedResult = "2")]
    public string GivenAccountCode_WhenGetNextCode_ShouldCode(string code)
    {
        var accountRepository = Substitute.For<IAccountRepository>();
        var accountType = new AccountTypeId(Guid.NewGuid());
        var lastAccountOfParent = Account.Create(accountRepository, code, "lorem ipsum", new AccountTypeId(Guid.NewGuid()), true);

        return AccountCode.GetNextCode(lastAccountOfParent);
    }
}