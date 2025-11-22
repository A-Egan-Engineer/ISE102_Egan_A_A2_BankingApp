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