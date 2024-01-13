using BankLib;

// Bank init
//
var bank = Bank.Instance;
bank.Name = "Super Simple Bank";



// Adding test accounts
//
var person = new IndividualClient("Ark", "Fen", "Montreal", "5553322");
var company = new CorporateClient("MoneyMakers", "New York", "5554411");
var accountCh = new CheckingAccount("0085511", person);
var accountInvInd = new InvestmentAccount("0085522", person);
var accountInvCorp = new InvestmentAccount("0085533", company);

await bank.AddAccountAsync(accountCh).ConfigureAwait(false);
await bank.AddAccountAsync(accountInvInd).ConfigureAwait(false);
await bank.AddAccountAsync(accountInvCorp).ConfigureAwait(false);



// Testing Deposit
//
await Transaction.DepositAsync("0085511", 12000).ConfigureAwait(false);
await Transaction.DepositAsync("0085522", 7000).ConfigureAwait(false);
await Transaction.DepositAsync("0085533", 50000).ConfigureAwait(false);

Console.WriteLine($"Account # {accountCh.Number} balance: {accountCh.Balance}");



// Testing Withdraw
//
await Transaction.WithdawAsync("0085522", 501).ConfigureAwait(false); ; // Can't withdraw more than 500 from Ind Inv Acc
await Transaction.WithdawAsync("0085533", 5000).ConfigureAwait(false); ; // No problem to withdraw a lot for corporate one...
Console.WriteLine($"Account # {accountInvCorp.Number} balance: {accountInvCorp.Balance}");



// Testing Transfer
//
await Transaction.TransferAsync("0085511", "0085522", 1500).ConfigureAwait(false); ; // investing little by little ))
Console.WriteLine($"Account # {accountCh.Number} balance: {accountCh.Balance}");
Console.WriteLine($"Account # {accountInvInd.Number} balance: {accountInvInd.Balance}");


// More test cases scenarios are implemented in the Unit Testing project... 
// here are just a few to prove the concept
