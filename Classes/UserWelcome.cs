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
            // Option to reset password
            Console.WriteLine("3. Exsisting User - Reset Password\n");
            // Option to exit application 
            Console.WriteLine("4. Exit Application\n");
            // Sets option string to entered option
            string option = Console.ReadLine()!;
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

                // Asks the user to change passowrd
                case "3":
                    Console.WriteLine("You have selected 'Reset Password'\n");
                    Console.WriteLine("Please enter a new password:\n");

                    // Reads the new password
                    string NewPassword = Console.ReadLine()!;

                    // Stores the new password
                    LoginClass.storedPassword = NewPassword;
                    SignUpClass.password = NewPassword;

                    Console.WriteLine("Your password has been successfully reset!\n");
                    break;

                // Exits application when 'Exit' is input 
                case "4":
                    Console.WriteLine("You have selected to Exit the Application!\n");
                    Console.WriteLine("Thank you for using our banking app!\n");
                    ExitApp.CloseApp();
                    Console.ReadLine();
                    break;

                default:
                    Console.WriteLine("The input is invalid, please try again!\n");
                    break;
            }
        }
        while (!optionOne || !optionTwo);
    }
}
