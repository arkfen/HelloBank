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

    }

    /// <summary>
    /// Transfering funds from one account to another
    /// </summary>
    /// <param name="senderAccNum">Sender Account</param>
    /// <param name="beneficiaryAccNum">Beneficiary Account</param>
    /// <param name="amount">Amount to transfer</param>
    public static async Task TransferAsync(string senderAccNum, string beneficiaryAccNum, decimal amount)
    {
        throw new NotImplementedException();
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
}
