namespace BankLib;

public class Transaction : ITransaction
{
    public static void Deposit(string accountNumber, decimal amount)
    {
        throw new NotImplementedException();
    }

    public static void Transfer(string senderAccNum, string beneficiaryAccNum, decimal amount)
    {
        throw new NotImplementedException();
    }

    public static void Withdaw(string accountNumber, decimal amount)
    {
        throw new NotImplementedException();
    }
}
