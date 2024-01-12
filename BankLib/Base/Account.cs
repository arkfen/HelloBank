namespace BankLib;

public abstract class Account : IAccount
{
    public string? Number { get; protected set; }
    public IClient? Owner { get; protected set; }
    public decimal Balance { get; protected set; }
    public decimal WithdrawLimit { get; protected set; }
    public bool IsProcessing { get; protected set; }

    public void InitDeposit(decimal amount)
    {
        throw new NotImplementedException();
    }
}
