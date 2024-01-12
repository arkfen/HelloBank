namespace BankLib;

public class Bank(string name) : IBank
{
    public string Name { get; } = name;

    public List<IAccount> Accounts { get; } = [];

    public async Task AddAccountAsync(IAccount account)
    {
        if (Accounts.Count(x => x.Number == account.Number) > 0)
        {
            // TO DO : log error "Account with this name already exists"
            Console.WriteLine("ERROR: Account with this name already exists!"); // temp
            return;
        }
        Accounts.Add(account);
        await Task.CompletedTask;
    }
}
