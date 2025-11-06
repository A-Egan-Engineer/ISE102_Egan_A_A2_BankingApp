using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace ConsoleBankApp;

class AppEntry
{
    static void Main(string[] args)
    {
        // User greeted when opening application
        Console.WriteLine("Welcome to the Banking App");
        // Call UserOption function to allow user to select if new or exsisting
        UserWelcome.UserOption();
        SignUpClass.SignUp();
        LoginClass.Login();
        Console.ReadLine();
    }
}

class UserWelcome
{
   static public void UserOption()
    {
        bool validOption = false;

        do
        {
            // Asks user to select one of the below options
            Console.WriteLine("Enter one of the options below:");
            // Option to create new account as new user
            Console.WriteLine("1. New User - Create New Account");
            // Option to Sign In as an exsisiting user
            Console.WriteLine("2. Exsiting User - Sign In");
            // Option to exit application
            Console.WriteLine("3. Exit Application");
            // Sets option string to entered option
            string option = Console.ReadLine();
            // Switch statement reads user input to select option
            switch (option)
            {
                // Asks user to create new account calling NewUser() function
                case "1":
                    Console.WriteLine("You have selected 'New User'");
                    validOption = true;
                    break;
                // Asks use to Sign In by calling SignIn() function
                case "2":
                    Console.WriteLine("You have selected 'Exsisting User'");
                    validOption = true;
                    break;
                // Exits application when 'Exit' is input
                case "3":
                    Console.WriteLine("You have selected to Exit the Application!");
                    Console.WriteLine("Thank you for using our banking app!");
                    ExitApp.CloseApp();
                    break;
                default:
                    Console.WriteLine("The input is invalid, please try again!");
                    break;
            }
        }
        while (validOption != true);
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

        do
        {
            Console.WriteLine("Please enter your username:");

            if (Console.ReadLine() == storedUsername)
            {
                Console.WriteLine("Please enter your password:");
                validUser = true;
            }
            else if (!validUser)
            {
                Console.WriteLine("Username entered is not registered!");
                Console.WriteLine("Select one of the options below:");
                Console.WriteLine("1. Try Username Again");
                Console.WriteLine("2. Exit Application");

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.WriteLine("You have selected 'Try Username Again'");
                        break;
                    case "2":
                        Console.WriteLine("You have selected 'Exit Application'");
                        Console.WriteLine("Thank you for using our banking app!");
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
                    Console.WriteLine("The username and password entered are valid!");
                    authentication = true;
                }
                else
                {
                    if (attempts < maxAttempts)
                    {
                        attempts++;
                        Console.WriteLine($"Incorrect password! You have {maxAttempts - (attempts - 1)} attempt(s) remaining!");
                        Console.WriteLine("Please enter your password:");
                    }
                    else
                    {
                        Console.WriteLine("Too many inncorect attempts password attempts!");
                        ExitApp.CloseApp();
                    }
                }
            }
            while (!authentication);
        }    
    }
}

class ExitApp
{
    static public async void CloseApp()
    {
        Console.WriteLine("The app will close in:");
        Console.WriteLine(5);
        await
        TimeDelay.OneSec();
        Console.WriteLine(4);
        await
        TimeDelay.OneSec();
        Console.WriteLine(3);
        await
        TimeDelay.OneSec();
        Console.WriteLine(2);
        await
        TimeDelay.OneSec();
        Console.WriteLine(1);
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