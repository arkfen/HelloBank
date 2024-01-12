using System.Reflection.Metadata.Ecma335;

namespace BankLib;

public interface IBank
{
    string Name { get; }
    List<IAccount> Accounts { get; }
    void SetName(string name);
    void AddAccount(IAccount account);
}
