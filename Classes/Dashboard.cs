using System.Globalization;

public class Dashboard
{
    private readonly string _displayName;
    private readonly List<Account> _accounts;

    public Dashboard(string displayName, string uniqueSeed)
    {
        _displayName = displayName;
        _accounts = GenerateSampleAccounts(uniqueSeed);
    }

    public void Run()
    {
        while (true)
        {
            Console.WriteLine($"Welcome {_displayName}");
            Console.WriteLine("1: View Balance");
            Console.WriteLine("2: Deposit");
            Console.WriteLine("3: Withdraw");
            Console.WriteLine("4: Transfer");
            Console.WriteLine("5: Quit");
            Console.Write("Select option: ");
            var choice = Console.ReadLine();
            Console.WriteLine();

            try
            {
                switch (choice)
                {
                    case "1": ShowBalances(); break;
                    case "2": DoDeposit(); break;
                    case "3": DoWithdraw(); break;
                    case "4": DoTransfer(); break;
                    case "5": ExitApp.CloseApp(); Console.ReadLine(); break;
                    default:
                        Console.WriteLine("Please choose 1-5.\n");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}\n");
            }
        }
    }

    // --- Helpers ---------------------------------------------------------

    private void ShowBalances()
    {
        Console.WriteLine("Accounts:");
        foreach (var a in _accounts)
            Console.WriteLine(a.ToString());
        Console.WriteLine();
    }

    private void DoDeposit()
    {
        var acc = PickAccount("Deposit to which account? ");
        var amount = PromptAmount("Enter deposit amount: ");
        acc.Deposit(amount);
        Console.WriteLine("Deposit successful.\n");
    }

    private void DoWithdraw()
    {
        var acc = PickAccount("Withdraw from which account? ");
        var amount = PromptAmount("Enter withdraw amount: ");
        acc.Withdraw(amount);
        Console.WriteLine("Withdrawal successful.\n");
    }

    private void DoTransfer()
    {
        var from = PickAccount("Transfer FROM which account? ");
        var to = PickAccount("Transfer TO which account? ");
        if (ReferenceEquals(from, to))
        {
            Console.WriteLine("Choose two different accounts.\n");
            return;
        }
        var amount = PromptAmount("Enter transfer amount: ");
        from.Withdraw(amount);
        to.Deposit(amount);
        Console.WriteLine("Transfer successful.\n");
    }

    private Account PickAccount(string prompt)
    {
        Console.WriteLine("Accounts:");
        for (int i = 0; i < _accounts.Count; i++)
            Console.WriteLine($"{i + 1}: {_accounts[i]}");
        Console.Write(prompt);

        if (!int.TryParse(Console.ReadLine(), out int idx) || idx < 1 || idx > _accounts.Count)
            throw new ArgumentException("Invalid account selection.");

        Console.WriteLine();
        return _accounts[idx - 1];
    }

    private static decimal PromptAmount(string prompt)
    {
        Console.Write(prompt);
        if (!decimal.TryParse(Console.ReadLine(), NumberStyles.Number, CultureInfo.InvariantCulture, out var amt) ||
            amt <= 0)
            throw new ArgumentException("Enter a positive number.");
        return decimal.Round(amt, 2);
    }

    private static List<Account> GenerateSampleAccounts(string seedKey)
    {
        // seed on user string so balances are "random" but repeatable per user
        int seed = seedKey?.GetHashCode() ?? Environment.TickCount;
        var rng = new Random(seed);

        decimal R(decimal min, decimal max)
        {
            // random decimal with 2 dp
            var v = (decimal)rng.NextDouble();
            var val = min + v * (max - min);
            return decimal.Round(val, 2);
        }

        string Num() => $"{rng.Next(100000, 999999)}-{rng.Next(100, 999)}";

        return new List<Account>
            {
                new Account(AccountType.Everyday, Num(), R(500m, 3000m)),
                new Account(AccountType.Savings,  Num(), R(1000m, 15000m)),
                new Account(AccountType.Credit,   Num(), R(0m, 2000m)) // treat as positive “available” for simplicity
            };
    }
}