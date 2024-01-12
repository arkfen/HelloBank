using System.Reflection.Metadata.Ecma335;

namespace BankLib;

public interface IAccount
{
    IClient Owner { get; set; }
    Decimal Balance { get; set; }
    Decimal WithdrawLimit { get; set; }
    void InitDeposit(Decimal amount);
}
