public class SignUpClass
{
    // Used to store username entered by user
    static public string ?username;
    // Used to store email entered by user
    static public string ?email;
    // Used to store age entered by user
    static public int age;
    // Used to store mobile number entered by user
    static public int mobileNumber;
    // Used to store password entered by user
    static public string ?password;

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
        age = int.Parse(Console.ReadLine()!);
        Console.WriteLine();
        // Asks user to enter mobile number
        Console.WriteLine("Enter your mobile number:\n");
        // mobileNumber set to user input
        mobileNumber = int.Parse(Console.ReadLine()!);
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