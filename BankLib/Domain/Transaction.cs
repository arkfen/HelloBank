namespace BankLib;

public class Transaction : ITransaction
{
    public static async Task DepositAsync(string accountNumber, decimal amount)
    {
        throw new NotImplementedException();
    }

    public static async Task TransferAsync(string senderAccNum, string beneficiaryAccNum, decimal amount)
    {
        throw new NotImplementedException();
    }

    public static async Task WithdawAsync(string accountNumber, decimal amount)
    {
        throw new NotImplementedException();
    }
}
