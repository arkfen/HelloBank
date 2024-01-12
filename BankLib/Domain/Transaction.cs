namespace BankLib;

public class Transaction : ITransaction
{
    public static async Task Deposit(string accountNumber, decimal amount)
    {
        throw new NotImplementedException();
    }

    public static async Task Transfer(string senderAccNum, string beneficiaryAccNum, decimal amount)
    {
        throw new NotImplementedException();
    }

    public static async Task Withdaw(string accountNumber, decimal amount)
    {
        throw new NotImplementedException();
    }
}
