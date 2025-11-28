class LoanApplication
{
    bool authentication = false;
    int maxAttempts = 3;

    public void ApplyForLoan()
    {
        Console.WriteLine($"Welcome to the loan application portal, {SignUpClass.username}!\n");
        
        Console.WriteLine("To begin your loan application, please enter your password:\n");

        for (int attempts = 1; attempts < maxAttempts;)
        {
            do
            {
                if (Console.ReadLine() == LoginClass.storedPassword)
                {
                    Console.WriteLine("The username and password entered are valid!\n");
                    authentication = true;
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
                    }
                }
            }
            while (!authentication);
        }

            Console.WriteLine("Please enter the amount you wish to borrow:\n");

            string loanAmount = Console.ReadLine()!;

            Console.WriteLine($"You have successfully applied for a loan of ${loanAmount}. Our team will review your application and get back to you in 3-5 business days!\n");       
        
    }
}