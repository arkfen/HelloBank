namespace BankLib;

public interface IAccount
{
    string Number { get; set; }
    IClient Owner { get; set; }
    Decimal Balance { get; set; }
    Decimal WithdrawLimit { get; set; }
    void InitDeposit(Decimal amount);
}
