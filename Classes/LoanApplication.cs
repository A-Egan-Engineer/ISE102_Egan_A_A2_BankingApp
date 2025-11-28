class LoanApplication
{
    bool authentication = false;

    void ApplyForLoan()
    {
        Console.WriteLine($"Welcome to the loan application portal, {SignUpClass.username}!\n");
        
        Console.WriteLine("To begin your loan application, please enter your password:\n");

        for (int attempts = 1; attempts <= 3; attempts++)
        {
            do
            {
                if (LoginClass.storedPassword == Console.ReadLine())
                {
                    authentication = true;
                    Console.WriteLine("Password Authenticated! You may proceed with your loan application.\n");
                    break;
                }
                else
                {if (attempts < 3)
                    {
                        Console.WriteLine("Invalid Password. Please try again:\n");
                    }
                    else
                    {
                        Console.WriteLine("Authentication Failed! Too many password attempts.\n");
                        Console.WriteLine("Exiting Loan Application.\n");
                    }
                }
            } while (!authentication);

        }

        
    }
}