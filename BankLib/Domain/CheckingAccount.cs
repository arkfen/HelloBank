namespace BankLib;

public class CheckingAccount(string number, IClient owner) : Account
{
    public override string Number { get; } = number;
    public override IClient Owner { get; } = owner;

}
