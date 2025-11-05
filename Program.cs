using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace ConsoleBankApp;

class Program
{
    // Used to store username entered by user
    static private string username;
    // Used to store email entered by user
    static private string email;
    // Used to store age entered by user
    static private int age;
    // Used to store mobile number entered by user
    static private int mobileNumber;
    // Used to store password entered by user
    static private string password;

    static void Main()
    {
        // User greeted when opening application
        Console.WriteLine("Welcome to the Banking App");
        // Call UserOption function to allow user to select if new or exsisting
        UserOption();
        ExsistingUser();
        Console.ReadLine();
    }

   static public void UserOption()
    {
        bool validOption = false;

        do
        {
            // Asks user to select one of the below options
            Console.WriteLine("Enter one of the options below:");
            // Option to create new account as new user
            Console.WriteLine("1. Enter 'New User' create new account");
            // Option to Sign In as an exsisiting user
            Console.WriteLine("2. Enter 'Existing User' to Sign In");
            // Option to exit application
            Console.WriteLine("3. Enter 'Exit' to exit application");
            // Sets option string to entered option
            string option = Console.ReadLine();
            // Switch statement reads user input to select option
            switch (option)
            {
                // Asks user to create new account calling NewUser() function
                case "New User":
                    Console.WriteLine("You have selected 'New User'");
                    validOption = true;
                    NewUser();
                    break;
                // Asks use to Sign In by calling SignIn() function
                case "Exsisting User":
                    Console.WriteLine("You have selected 'Exsisting User'");
                    validOption = true;
                    break;
                // Exits application when 'Exit' is input
                case "Exit":
                    Console.WriteLine("You have selected to Exit the Application!");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("The input is invalid, please try again!");
                    break;
            }
        }
        while (validOption != true);
    }
    static public void NewUser()
    {

        // Asks user to enter a new username
        Console.WriteLine("Please enter a new username for your account:");
        // username set to user input
        username = Console.ReadLine();
        // Asks user to enter an email
        Console.WriteLine("Enter your email:");
        // email set to user input
        email = Console.ReadLine();
        // Asks user to enter age
        Console.WriteLine("Enter your age:");
        // age set to user input
        age = int.Parse(Console.ReadLine());
        // Asks user to enter mobile number
        Console.WriteLine("Enter your mobile number:");
        // mobileNumber set to user input
        mobileNumber = int.Parse(Console.ReadLine());
        // Asks user to enter a password
        Console.WriteLine("Enter a password:");
        // password set to user input
        password = Console.ReadLine();
        // Relays information entered to user minus the password
        Console.WriteLine($"Your information is - Username: {username} Email: {email} Age: {age} Mobile: {mobileNumber}");
    }

    static public async Task ExsistingUser()
    {
        // bool used to verify correct username
        bool correctUser = false;
        // Prompts user to enter username
        Console.WriteLine("You have selected Sign In!");
        Console.WriteLine("Please enter your username:");
        // While username is not correct, continue to ask for username or allow user to exit application
        do
            // If user enters correct username, alert user the username is correct
            if (Console.ReadLine() == username)
            {
                Console.WriteLine("The username entered is correct!");
                // Sets correctUser to true to allow exit of do-while loop
                correctUser = true;
            }
            else
            {
                // Gives the user the option of trying again or exiting application after invalid username input
                Console.WriteLine("The username you have entered is not valid!");
                Console.WriteLine("Please select an option from below:");
                Console.WriteLine("1. Try Again");
                Console.WriteLine("2. Exit Application");
                // Reads user input to verify the option they have selected
                string option = Console.ReadLine();
                // Switch statement to handle user decision to try again or exit the application
                switch (option)
                {
                    // Runs when user inputs '1' as repsonse, allowing the user to try again
                    case "1":
                        Console.WriteLine("Please try entering your username again:");
                        break;
                    // Exits application when user inputs '2' as response, application closes after 5 seconds
                    case "2":
                        Console.WriteLine("Thank you for using our banking app!");
                        Console.WriteLine("The Application will exit in:");
                        Console.WriteLine(5);
                        await
                        OneSec();    
                        Console.WriteLine(4);
                        await
                        OneSec();
                        Console.WriteLine(3);
                        await
                        OneSec();
                        Console.WriteLine(2);
                        await
                        OneSec();
                        Console.WriteLine(1);
                        await 
                        OneSec();
                        Environment.Exit(0);
                        break;

                }
            }
        // Loop continues for as long as the username is incorrect (Unless user decides to exit application after failed attempt)
        while (correctUser != true);
    }
    // Delay function to delay 1 second before continuing code execution
    static public async Task OneSec()
    {
        await Task.Delay(1000);
    }
}