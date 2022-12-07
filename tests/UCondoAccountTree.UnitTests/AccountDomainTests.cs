using NSubstitute;
using UCondoAccountTree.Domain.AggregatesModels.AccountTypes;
using UCondoAccountTree.Domain.SeedWorks;

namespace UCondoAccountTree.Domain.Tests;

[TestFixture]
public class AccountDomainTests
{
    [Test]
    public void GivenAccountWithBilling_WhenAssociateAParentAccount_ShouldBusinessException()
    {
        const bool hasBillingAccount = true;
        var accountRepository = Substitute.For<IAccountRepository>();
        var accountType = AccountType.Create("Lorem Ipsum");
        var parentAccount = Account.Create(accountRepository, "1", "Parent Account", accountType.AccountTypeId, hasBillingAccount);

        var ruleValidationException = Assert.Throws<BusinessRuleValidationException>(
            delegate { Account.CreateChildAccount(accountRepository, parentAccount, "1.1", "Children Account", accountType, false); });

        Assert.That(ruleValidationException.Message, Is.EqualTo("Account with billing cannot parent"));
    }

    [Test]
    public void GivenAccount_WhenParentAccount_ShouldSuccessCreated()
    {
        var accountRepository = Substitute.For<IAccountRepository>();
        var accountTypeId = new AccountTypeId(Guid.NewGuid());
        var newAccount = Account.Create(accountRepository, "1", "Parent Account", accountTypeId, false);

        Assert.AreSame(newAccount.AccountCode.Value, "1");
        Assert.AreEqual(newAccount.Name, "Parent Account");
        Assert.AreEqual(newAccount.AcceptBilling, false);
    }

    [Test]
    public void GivenAccount_WhenParentAndAccountTypeDifferent_ShouldBusinessException()
    {
        var accountRepository = Substitute.For<IAccountRepository>();
        const bool hasBillingAccount = false;
        var accountType = AccountType.Create("Lorem Ipsum");
        var parentAccount = Account.Create(accountRepository, "1", "Parent Account", accountType.AccountTypeId, hasBillingAccount);

        var ruleValidationException = Assert.Throws<BusinessRuleValidationException>(
            delegate { Account.CreateChildAccount(accountRepository, parentAccount, "1.1", "Children Account", accountType, false); });

        Assert.That(ruleValidationException.Message, Is.EqualTo("Account Type must be same parent"));
    }
}