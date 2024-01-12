
using System.Net.Http.Headers;

namespace BankLib;

public class Bank(string name) : IBank
{
    public string Name { get; } = name;

    public List<IAccount> Accounts { get; } = [];

    public void AddAccount(IAccount account)
    {
        throw new NotImplementedException();
    }
}
