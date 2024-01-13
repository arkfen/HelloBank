namespace BankLib;

public class InvestmentAccount : Account
{
    public enum OwenershipType
    {
        Individual,
        Corporate
    }

    public const decimal WithdrawLimitIndAcc = 500;

    public override string? Number { get; protected set; }
    public override IClient? Owner { get; protected set; }
    public OwenershipType Type { get; set; }

    public InvestmentAccount(string number, IClient owner)
    {
        Number = number;
        Owner = owner;

        if (owner.GetType() == typeof(IndividualClient))
        {
            Type = OwenershipType.Individual;
            WithdrawLimit = WithdrawLimitIndAcc;
        }
        if (owner.GetType() == typeof(CorporateClient))
        {
            Type = OwenershipType.Corporate;
        }
    }


}
