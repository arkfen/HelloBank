namespace BankLib;

public abstract class Account : IAccount
{
    public virtual string? Number { get; protected set; }
    public virtual IClient? Owner { get; protected set; }
    public decimal Balance { get; protected set; }
    public decimal WithdrawLimit { get; protected set; }
    public bool IsProcessing { get; protected set; }


}
