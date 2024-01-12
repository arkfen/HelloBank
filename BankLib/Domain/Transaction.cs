namespace BankLib;

public class Transaction : ITransaction
{
    public void Deposit(string accountNumber, decimal amount)
    {
        throw new NotImplementedException();
    }

    public void Transfer(string senderAccNum, string beneficiaryAccNum, decimal amount)
    {
        throw new NotImplementedException();
    }

    public void Withdaw(string accountNumber, decimal amount)
    {
        throw new NotImplementedException();
    }
}
