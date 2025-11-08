using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace ConsoleBankApp;

class AppEntry
{
    static void Main(string[] args)
    {
        // User greeted when opening application
        Console.WriteLine("Welcome to the Banking App\n");
        // Call UserOption function to allow user to select if new or exsisting
        UserWelcome.UserOption();
        Console.ReadLine();
    }
}

class UserWelcome
{
   static public void UserOption()
    {
        bool optionOne = false;
        bool optionTwo = false;

        do
        {
            // Asks user to select one of the below options
            Console.WriteLine("Enter one of the options below:\n");
            // Option to create new account as new user
            Console.WriteLine("1. New User - Create New Account\n");
            // Option to Sign In as an exsisiting user
            Console.WriteLine("2. Exsiting User - Sign In\n");
            // Option to exit application
            Console.WriteLine("3. Exit Application\n");
            // Sets option string to entered option
            string option = Console.ReadLine();
            Console.WriteLine();
            // Switch statement reads user input to select option
            switch (option)
            {
                // Asks user to create new account calling NewUser() function
                case "1":
                    Console.WriteLine("You have selected 'New User'\n");
                    optionOne = true;
                    SignUpClass.SignUp();
                    break;
                // Asks use to Sign In by calling SignIn() function
                case "2":
                    Console.WriteLine("You have selected 'Exsisting User'\n");
                    optionTwo = true;
                    LoginClass.Login();
                    break;
                // Exits application when 'Exit' is input
                case "3":
                    Console.WriteLine("You have selected to Exit the Application!\n");
                    Console.WriteLine("Thank you for using our banking app!\n");
                    ExitApp.CloseApp();
                    break;
                default:
                    Console.WriteLine("The input is invalid, please try again!\n");
                    break;
            }
        }
        while (!optionOne || !optionTwo );
    }
}

class SignUpClass
{
    // Used to store username entered by user
    static public string username;
    // Used to store email entered by user
    static public string email;
    // Used to store age entered by user
    static public int age;
    // Used to store mobile number entered by user
    static public int mobileNumber;
    // Used to store password entered by user
    static public string password;

    static public void SignUp()
    {

        // Asks user to enter a new username
        Console.WriteLine("Please enter a new username for your account:\n");
        // username set to user input
        username = Console.ReadLine();
        Console.WriteLine();
        // Asks user to enter an email
        Console.WriteLine("Enter your email:\n");
        // email set to user input
        email = Console.ReadLine();
        Console.WriteLine();
        // Asks user to enter age
        Console.WriteLine("Enter your age:\n");
        // age set to user input
        age = int.Parse(Console.ReadLine());
        Console.WriteLine();
        // Asks user to enter mobile number
        Console.WriteLine("Enter your mobile number:\n");
        // mobileNumber set to user input
        mobileNumber = int.Parse(Console.ReadLine());
        Console.WriteLine();
        // Asks user to enter a password
        Console.WriteLine("Enter a password:\n");
        // password set to user input
        password = Console.ReadLine();
        Console.WriteLine();
        // Relays information entered to user minus the password
        Console.WriteLine($"Account registration successful!\n");
        Console.WriteLine("Please Login using your registered information!\n");
    }
}

class LoginClass
{
    static public string storedUsername = SignUpClass.username;
    static public string storedPassword = SignUpClass.password;

    static public void Login()
    {
        int maxAttempts = 3;
        bool authentication = false;
        bool validUser = false;

        Dashboard dashboard = new Dashboard(SignUpClass.username, "01010101");

        Console.WriteLine("Please enter your username:\n");

        do
        {       
            if (Console.ReadLine() == storedUsername)
            {
                Console.WriteLine();
                Console.WriteLine("Please enter your password:\n");
                validUser = true;
            }
            else if (!validUser)
            {
                Console.WriteLine("Username entered is not registered!\n");
                Console.WriteLine("Select one of the options below:\n");
                Console.WriteLine("1. Try Username Again\n");
                Console.WriteLine("2. Exit Application\n");

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.WriteLine("You have selected 'Try Username Again'\n");
                        Console.WriteLine("Please enter your username:");
                        break;
                    case "2":
                        Console.WriteLine("You have selected 'Exit Application'\n");
                        Console.WriteLine("Thank you for using our banking app!\n");
                        ExitApp.CloseApp();
                        break;
                }

            }
        } while (!validUser);

        for (int attempts = 1; attempts < maxAttempts;)
        {
            do
            {
                if (validUser = true && Console.ReadLine() == storedPassword)
                {
                    Console.WriteLine("The username and password entered are valid!\n");
                    authentication = true;
                    dashboard.Run();
                }
                else
                {
                    if (attempts < maxAttempts)
                    {
                        attempts++;
                        Console.WriteLine($"Incorrect password! You have {maxAttempts - (attempts - 1)} attempt(s) remaining!\n");
                        Console.WriteLine("Please enter your password:\n");
                    }
                    else
                    {
                        Console.WriteLine("Too many inncorect attempts password attempts!\n");
                        ExitApp.CloseApp();
                    }
                }
            }
            while (!authentication);
        }    
    }
}


public enum AccountType { Everyday, Savings, Credit }

public class Account
{
    public string AccountNumber { get; }
    public AccountType Type { get; }
    public decimal Balance { get; private set; }

    public Account(AccountType type, string number, decimal opening)
    {
        Type = type;
        AccountNumber = number;
        Balance = opening;
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0) throw new ArgumentException("Amount must be positive.");
        Balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= 0) throw new ArgumentException("Amount must be positive.");
        if (amount > Balance) throw new InvalidOperationException("Insufficient funds.");
        Balance -= amount;
    }

    public override string ToString()
        => $"{Type,-8}  {AccountNumber}   {Balance.ToString("C", CultureInfo.CurrentCulture)}";
}

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
                    case "5": ExitApp.CloseApp(); break;
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


class ExitApp
{
    static public async void CloseApp()
    {
        Console.WriteLine("The app will close in:\n");
        Console.WriteLine("5\n");
        await
        TimeDelay.OneSec();
        Console.WriteLine("4\n");
        await
        TimeDelay.OneSec();
        Console.WriteLine("3\n");
        await
        TimeDelay.OneSec();
        Console.WriteLine("2\n");
        await
        TimeDelay.OneSec();
        Console.WriteLine("1\n");
        await
        TimeDelay.OneSec();
        Environment.Exit(0);
    }
}

class TimeDelay
{
    // Delay function to delay 1 second before continuing code execution
    static public async Task OneSec()
    {
        await Task.Delay(1000);
    }
}