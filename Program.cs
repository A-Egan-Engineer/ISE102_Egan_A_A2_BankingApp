namespace ConsoleBankApp;
    
class Program
{
    static void Main()
    {
        // User greeted when opening application
        Console.WriteLine("Welcome to the Banking App");
        // Confirming if user is a new or returning user
        Console.WriteLine("Are you a first time user?");
        // Allowing user to make selection to sign in or register for app
        Console.WriteLine("Enter: Y = Yes or N = No");
        // Read users input for decision
        string answerOne = Console.ReadLine();
        // Decide outcome based on users input
        if(answerOne == ("Y"))
        {
            // Insert Register Function Here
        }
        else if (answerOne == ("N"))
        {
            // Insert Sign In Function Here
        }
        Console.ReadLine();
    }

    static void UserOption()
    {
        string option = Console.ReadLine();

        switch (option)
        {
            case "New User":
                Console.WriteLine("");
                break;
        }
    }
}