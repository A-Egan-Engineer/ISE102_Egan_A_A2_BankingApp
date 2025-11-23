class LoginClass
{
    static public string storedUsername = SignUpClass.username!;
    static public string storedPassword = SignUpClass.password!;

    static public void Login()
    {
        int maxAttempts = 3;
        bool authentication = false;
        bool validUser = false;

        Dashboard dashboard = new Dashboard(SignUpClass.username!, "01010101");

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

                string option = Console.ReadLine()!;

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
