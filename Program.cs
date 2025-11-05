using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleBankApp;

class Program
{
    // Used to store username entered by user
    private string username;
    // Used to store email entered by user
    private string email;
    // Used to store age entered by user
    private int age;
    // Used to store mobile number entered by user
    private int mobileNumber;
    // Used to store password entered by user
    private string password;

    public void Main()
    {
        // User greeted when opening application
        Console.WriteLine("Welcome to the Banking App");
        // Call UserOption function to allow user to select if new or exsisting
        UserOption();
        Console.ReadLine();
    }

    public void UserOption()
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
                NewUser();
                break;
            // Asks use to Sign In by calling SignIn() function
            case "Exsisting User":
                Console.WriteLine("You have selected 'Exsisting User'");
                break;
            // Exits application when 'Exit' is input
            case "Exit":
                Console.WriteLine("You have selected to Exit the Application!");
                Environment.Exit(0);
                break;
        }
    }
    public void NewUser()
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

    public void ExsistingUser()
    {
        bool correctUser = false;

        Console.WriteLine("You have selected Sign In!");
        Console.WriteLine("Please enter your username:");

        do
            if (Console.ReadLine() == username)
            {
                Console.WriteLine("The username entered is correct!");
            }
            else if (Console.ReadLine() != username)
            {
                Console.WriteLine("The username you have entered is not valid!");
                Console.WriteLine("Please select an option from below:");
                Console.WriteLine("1. Try Again");
                Console.WriteLine("2. Exit Application");

                string option = Console.ReadLine();

                switch(option)
                {
                    case "1":
                        Console.WriteLine("Please try entering");
                        break;
                }    
            }
        while (correctUser != true);
    }
}