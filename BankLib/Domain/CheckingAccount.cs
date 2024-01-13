namespace BankLib;

public class CheckingAccount(string number, IClient owner) : Account
{
    public override string? Number { get; protected set; } = number;
    public override IClient? Owner { get; protected set; } = owner;

}
