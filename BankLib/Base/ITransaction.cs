namespace BankLib;

public interface ITransaction
{
    static abstract Task DepositAsync(string accountNumber, decimal amount);
    static abstract Task WithdawAsync(string accountNumber, decimal amount);
    static abstract Task TransferAsync(string senderAccNum, string beneficiaryAccNum, decimal amount);
}
