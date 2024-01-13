namespace BankLib;

public interface IBank
{
    string? Name { get; }
    List<IAccount> Accounts { get; }
    Task AddAccountAsync(IAccount account);
}
