namespace BankLib;

public abstract class Account : IAccount
{
    public virtual string? Number { get; }
    public virtual IClient? Owner { get; }
    public decimal Balance { get; protected set; }
    public decimal WithdrawLimit { get; protected set; }
    public bool IsProcessing { get; protected set; }


}
