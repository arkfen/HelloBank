namespace BankLib;

public class IndividualClient(string firstName, string lastName, string address, string telephone) : IClient
{
    public string Address { get; } = address;
    public string Telephone { get; } = telephone;
    public string firstName { get; } = firstName;
    public string lastName { get; } = lastName;
}
