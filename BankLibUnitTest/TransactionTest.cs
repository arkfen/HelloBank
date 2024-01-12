using System.Security.Cryptography;
using BankLib;

namespace BankLibUnitTest;

[TestClass]
public class TransactionTest
{
    static Bank bank = new("Simplle Bank");
    static IClient person = new IndividualClient("Ark", "Fen", "Montreal", "5553322");
    static IClient company = new CorporateClient("MoneyMakers", "New York", "5554411");
    static IAccount accountCh = new CheckingAccount("0085511", person);
    static IAccount accountInvInd = new InvestmentAccount("0085522", person);
    static IAccount accountInvCorp = new InvestmentAccount("0085533", company);

    static decimal depositAmount = 100;
    static decimal transferAmount = 700;
    static decimal withdrawAmountLow = 300;
    static decimal withdrawAmountHigh = 1000;
    static decimal withdrawAmountHuge = 1000000;


    public TransactionTest()
    {
        _ = Init();
    }

    static async Task Init()
    {
        await Transaction.DepositAsync(accountCh.Number!, 10000).ConfigureAwait(false); ;
        await Transaction.DepositAsync(accountInvInd.Number!, 10000).ConfigureAwait(false); ;
        await Transaction.DepositAsync(accountInvCorp.Number!, 10000).ConfigureAwait(false); ;
        await bank.AddAccountAsync(accountCh).ConfigureAwait(false); ;
        await bank.AddAccountAsync(accountInvInd).ConfigureAwait(false); ;
        await bank.AddAccountAsync(accountInvCorp).ConfigureAwait(false); ;
    }

    /// <summary>
    /// Testing depositing to Checking Account
    /// </summary>    
    [TestMethod]
    public async Task TestDeposit_Checking()
    {
        var initialBalance = accountCh.Balance;
        await Transaction.DepositAsync(accountCh.Number!, depositAmount);
        var newBalance = accountCh.Balance;
        var result = newBalance == initialBalance + depositAmount;
        Assert.IsTrue(result, $"Expected for amount'{depositAmount}': true; Actual: {result}");
    }

    /// <summary>
    /// Testing depositing to Individual Investment Account
    /// </summary>
    [TestMethod]
    public async Task TestDeposit_InvestmentInd()
    {
        var initialBalance = accountInvInd.Balance;
        await Transaction.DepositAsync(accountInvInd.Number!, depositAmount);
        var newBalance = accountInvInd.Balance;
        var result = newBalance == initialBalance + depositAmount;
        Assert.IsTrue(result, $"Expected for amount'{depositAmount}': true; Actual: {result}");
    }


    /// <summary>
    /// Testing depositing to Corporate Investment Account
    /// </summary>
    [TestMethod]
    public async Task TestDeposit_InvestmentCorp()
    {
        var initialBalance = accountInvCorp.Balance;
        await Transaction.DepositAsync(accountInvCorp.Number!, depositAmount);
        var newBalance = accountInvCorp.Balance;
        var result = newBalance == initialBalance + depositAmount;
        Assert.IsTrue(result, $"Expected for amount'{depositAmount}': true; Actual: {result}");
    }


    /// <summary>
    /// Testing trasnfering from Checking to Individual Investment Account
    /// </summary>
    [TestMethod]
    public async Task TestTransfer_Checking_InvestmentInd()
    {
        var initialBalanceSender = accountCh.Balance;
        var initialBalanceBeneficiary = accountInvInd.Balance;
        await Transaction.TransferAsync(accountCh.Number!, accountInvInd.Number!, transferAmount);
        var newBalanceSender = accountCh.Balance;
        var newBalanceBeneficiary = accountInvInd.Balance;
        var result = (newBalanceSender == initialBalanceSender - transferAmount) &&
            (newBalanceBeneficiary == initialBalanceBeneficiary + transferAmount);
        Assert.IsTrue(result, $"Expected for amount'{transferAmount}': true; Actual: {result}");
    }



    /// <summary>
    /// Testing withdrawing from the Checking account less than on the balance
    /// </summary>
    [TestMethod]
    public async Task TestWithdraw_Checking_Normal()
    {
        var initialBalance = accountCh.Balance;
        await Transaction.WithdawAsync(accountCh.Number!, withdrawAmountLow);
        var newBalance = accountCh.Balance;
        var result = newBalance == initialBalance - withdrawAmountLow;
        Assert.IsTrue(result, $"Expected for amount'{depositAmount}': true; Actual: {result}");
    }


    /// <summary>
    /// Testing withdrawing from the Checking account MORE than on the balance
    /// </summary>
    [TestMethod]
    public async Task TestWithdraw_Checking_Overdraft()
    {
        var initialBalance = accountCh.Balance;
        await Transaction.WithdawAsync(accountCh.Number!, withdrawAmountHuge);
        var newBalance = accountCh.Balance;
        var result = newBalance == initialBalance - withdrawAmountHuge;
        Assert.IsFalse(result, $"Expected for amount'{depositAmount}': false; Actual: {result}");
    }


    /// <summary>
    /// Testing withdrawing from the Individual Investment account (less than limit)
    /// </summary>
    [TestMethod]
    public async Task TestWithdraw_IndInv_Normal()
    {
        var initialBalance = accountInvInd.Balance;
        await Transaction.WithdawAsync(accountCh.Number!, withdrawAmountLow);
        var newBalance = accountInvInd.Balance;
        var result = newBalance == initialBalance - withdrawAmountLow;
        Assert.IsTrue(result, $"Expected for amount'{depositAmount}': true; Actual: {result}");
    }


    /// <summary>
    /// Testing withdrawing from the Individual Investment account (MORE than limit)
    /// </summary>
    [TestMethod]
    public async Task TestWithdraw_IndInv_OverLimit()
    {
        var initialBalance = accountInvInd.Balance;
        await Transaction.WithdawAsync(accountCh.Number!, withdrawAmountHigh);
        var newBalance = accountInvInd.Balance;
        var result = newBalance == initialBalance - withdrawAmountHigh;
        Assert.IsFalse(result, $"Expected for amount'{depositAmount}': false; Actual: {result}");
    }


}
