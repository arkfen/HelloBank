namespace BankLib;

public interface ITransaction
{
    void Deposit(string accountNumber, decimal amount);
    void Withdaw(string accountNumber, decimal amount);
    void Transfer(string senderAccNum, string beneficiaryAccNum, decimal amount);
}
