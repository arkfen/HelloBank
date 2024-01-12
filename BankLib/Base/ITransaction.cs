namespace BankLib;

public interface ITransaction
{
    static abstract void Deposit(string accountNumber, decimal amount);
    static abstract void Withdaw(string accountNumber, decimal amount);
    static abstract void Transfer(string senderAccNum, string beneficiaryAccNum, decimal amount);
}
