using BankLib;

namespace BankLibUnitTest;

[TestClass]
public class BankTest
{
    static Bank bank = Bank.Instance;
    static IClient person = new IndividualClient("Ark", "Fen", "Montreal", "5553322");
    static IClient company = new CorporateClient("MoneyMakers", "New York", "5554411");
    static IAccount? account;

    public BankTest()
    {
        bank.Name = "Simplle Bank";
    }

    /// <summary>
    /// Testinng adding Checking account
    /// </summary>
    [TestMethod]
    public async Task TestAddAccount_Checking()
    {
        string accNumber = "0007722";
        account = new CheckingAccount(accNumber, person);
        await bank.AddAccountAsync(account);
        var accFound = bank.Accounts.First(x => x.Number == accNumber && x.Owner == person);
        var result = accFound is null ? false : true;
        Assert.IsTrue(result, $"Expected for acc# '{accNumber}': true; Actual: {result}");
    }

    /// <summary>
    /// Testing adding Individual Investment account
    /// </summary>
    [TestMethod]
    public async Task TestAddAccount_InvestmentInd()
    {
        string accNumber = "0007733";
        account = new InvestmentAccount(accNumber, person);
        await bank.AddAccountAsync(account);
        var accFound = bank.Accounts.First(x => x.Number == accNumber && x.Owner == person);
        var result = accFound is null ||
            accFound.WithdrawLimit != InvestmentAccount.WithdrawLimitIndAcc ? false : true;
        Assert.IsTrue(result, $"Expected for acc# '{accNumber}': true; Actual: {result}");
    }

    /// <summary>
    /// Testing adding Corporate Investment account
    /// </summary>
    [TestMethod]
    public async Task TestAddAccount_InvestmentIndCorp()
    {
        string accNumber = "0007744";
        account = new InvestmentAccount(accNumber, company);
        await bank.AddAccountAsync(account);
        var accFound = bank.Accounts.First(x => x.Number == accNumber && x.Owner == company);
        var result = accFound is null ? false : true;
        Assert.IsTrue(result, $"Expected for acc# '{accNumber}': true; Actual: {result}");
    }

    /// <summary>
    /// Testing against adding more than one account with the same number
    /// </summary>
    [TestMethod]
    public async Task TestAddAccount_Checking_Duplication()
    {
        string accNumber = "0007755";
        account = new CheckingAccount(accNumber, person);
        await bank.AddAccountAsync(account).ConfigureAwait(true);
        account = new CheckingAccount(accNumber, person);
        await bank.AddAccountAsync(account).ConfigureAwait(true);
        var numeberOfAcc = bank.Accounts.Count(x => x.Number == accNumber && x.Owner == person);
        var result = numeberOfAcc > 0 ? false : true;
        Assert.IsFalse(result, $"Expected for acc# '{accNumber}': false; Actual: {result}");
    }
}
