namespace UCondoAccountTree.Domain.Tests;

[TestFixture]
public class AccountCodeDomainTests
{
    [TestCase("1.9.8", ExpectedResult = "1.9.9")]
    [TestCase("1.999", ExpectedResult = "2")]
    [TestCase("2.2.10.999", ExpectedResult = "2.2.11")]
    [TestCase("2.2", ExpectedResult = "2.3")]
    [TestCase("2.999.999.999", ExpectedResult = "3")]
    public string GivenAccountCode_WhenGetNextCode_ShouldCode(string code)
    {
        var accountType = new TypedId(Guid.NewGuid());
        var lastAccountOfParent = Account.Create(code, "lorem ipsum", new AccountType(accountType, "lorem ipsum"), true);
        
        return AccountCode.GetNextCode(lastAccountOfParent);
    }
}