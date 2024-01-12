namespace BankLib;

public struct CorporateClient(string Name, string address, string telephone) : IClient
{
    public string Address { get; } = address;
    public string Telephone { get; } = telephone;
    public string firstName { get; } = Name;
}
