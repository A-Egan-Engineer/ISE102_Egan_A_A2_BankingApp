using System.Globalization;

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