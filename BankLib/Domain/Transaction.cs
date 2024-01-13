using System.Security.Cryptography;

namespace BankLib;


public class Transaction : ITransaction
{
    /// <summary>
    /// Depositing funds to the account
    /// </summary>
    /// <param name="accountNumber">Account number</param>
    /// <param name="amount">Amount to deposit</param>
    public static async Task DepositAsync(string accountNumber, decimal amount)
    {
        IAccount? acc = null;
        bool accProccessingStarted = false;
        try
        {
            acc = await GetAccountByNumberAsync(accountNumber).ConfigureAwait(true);
            if (acc is null) throw new ApplicationException("Account not found.");
            acc.IsProcessing = true;
            accProccessingStarted = true;
            acc.Balance += amount;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            if (acc is not null && accProccessingStarted)
            {
                acc.IsProcessing = false;
            }
        }
    }

    /// <summary>
    /// Transfering funds from one account to another
    /// </summary>
    /// <param name="senderAccNum">Sender Account</param>
    /// <param name="beneficiaryAccNum">Beneficiary Account</param>
    /// <param name="amount">Amount to transfer</param>
    public static async Task TransferAsync(string senderAccNum, string beneficiaryAccNum, decimal amount)
    {
        IAccount? accSend = null;
        IAccount? accBenif = null;
        bool accSendProccessingStarted = false;
        bool accBenifProccessingStarted = false;
        try
        {
            accSend = await GetAccountByNumberAsync(senderAccNum).ConfigureAwait(true);
            accBenif = await GetAccountByNumberAsync(beneficiaryAccNum).ConfigureAwait(true);
            if (accSend is null) throw new ApplicationException("Sender account not found.");
            if (accBenif is null) throw new ApplicationException("Beneficiary account not found.");
            accSend.IsProcessing = true;
            accSendProccessingStarted = true;
            accBenif.IsProcessing = true;
            accBenifProccessingStarted = true;

            if (amount > accSend.Balance) throw new ArgumentException("Not enough funds, sorry");
            accSend.Balance -= amount;
            accBenif.Balance += amount;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            if (accSend is not null && accSendProccessingStarted)
            {
                accSend.IsProcessing = false;
            }
            if (accBenif is not null && accBenifProccessingStarted)
            {
                accBenif.IsProcessing = false;
            }
        }
    }

    /// <summary>
    /// Withdraing specific amount from the bank account
    /// </summary>
    /// <param name="accountNumber">Account Number to withdraw from</param>
    /// <param name="amount">Amount to withdraw</param>
    public static async Task WithdawAsync(string accountNumber, decimal amount)
    {
        throw new NotImplementedException();
    }



    private static async Task<IAccount?> GetAccountByNumberAsync(string number)
    {
        var acc = Bank.Instance.Accounts.FirstOrDefault(x => x.Number == number);
        await Task.CompletedTask;
        return acc;
    }
}
