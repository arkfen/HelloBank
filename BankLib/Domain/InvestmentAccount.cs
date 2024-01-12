namespace BankLib;

public class InvestmentAccount(string number, IClient owner) : Account
{
    enum AccType
    {
        Individual,
        Corporate
    }

    public override string Number { get; } = number;
    public override IClient Owner { get; } = owner;
    AccType Type
    {
        get
        {
            return type;
        }
        set
        {
            if (Owner.GetType() == typeof(IndividualClient))
            {
                type = AccType.Individual;
                WithdrawLimit = 500;
            }
            if (Owner.GetType() == typeof(CorporateClient))
            {
                type = AccType.Corporate;
            }
        }
    }
    private AccType type;



}
