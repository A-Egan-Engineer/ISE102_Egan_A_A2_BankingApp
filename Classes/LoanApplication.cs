class LoanApplication
{
    void ApplyForLoan()
    {
        Console.WriteLine($"Welcome to the loan application portal, {SignUpClass.username}!\n");
        
        Console.WriteLine("To begin your loan application, please enter your password:\n");

        if (Console.ReadLine() == LoginClass.storedPassword)
        {
            Console.WriteLine("Password accepted! You may now proceed with your loan application.\n");
        }
        else
        {
            Console.WriteLine("Incorrect password. Please try again later.\n");
            
        }
    }
}