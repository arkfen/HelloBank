namespace BankLib;

public interface IAccount
{
    string? Number { get; }
    IClient? Owner { get; }
    Decimal Balance { get; }
    Decimal WithdrawLimit { get; }
    bool IsProcessing { get; }
}
