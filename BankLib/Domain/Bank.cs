namespace BankLib;

public sealed class Bank : IBank
{
    private static readonly Bank instance = new();
    public string? Name { get; set; }
    public List<IAccount> Accounts { get; } = [];
    public static Bank Instance { get => instance; }

    static Bank()
    {

    }
    private Bank()
    {

    }


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
