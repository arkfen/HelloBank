namespace BankLib;

public class Bank(string name) : IBank
{
    public string Name { get; } = name;

    public List<IAccount> Accounts { get; } = [];

    /// <summary>
    /// Adding new bank account to the Bank with unique account number
    /// </summary>
    /// <param name="account">Account Object</param>
    /// <returns>Completed Task (void)</returns>
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
