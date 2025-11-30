class LoanApplication
{
    string username = LoginClass.storedUsername; // Get the logged-in username
    string ?password;

    public void ApplyForLoan() // Method to handle loan application
    {
        Console.WriteLine("Loan Application Process Initiated.\n"); // Welcomes user to loan application

        Console.WriteLine("Please re-enter your password to proceed:\n"); // Prompts user to re-enter password

        password = Console.ReadLine()!; // Reads password input

        for (int attempts = 1; attempts <= 3; attempts++) // Allows up to 3 attempts for password entry
        {
            if (password == LoginClass.storedPassword) // Validates password input
            {
                Console.WriteLine("Password verified successfully!\n"); // Confirms successful password verification
                break; // Exit loop if password is correct
            }
            else if (attempts < 3) // If attempts are less than 3, prompt user again
            {
                Console.WriteLine("Incorrect password. Please try again:\n"); // Prompts user again if password is incorrect
                password = Console.ReadLine()!; // Reads password input again
            }
            else // If maximum attempts reached, exit application
            {
                Console.WriteLine("Maximum attempts reached. Exiting Loan application.\n"); // Informs user of maximum attempts reached
                ExitApp.CloseApp(); // Calls method to close application
                return; // Exit method
            }
        }

        Console.WriteLine("Please enter the loan amount you wish to apply for:\n"); // Prompts user for loan amount
        string loanAmountInput = Console.ReadLine()!; // Reads loan amount user inputs
        decimal loanAmount; // Variable to store parsed loan amount

        while (!decimal.TryParse(loanAmountInput, out loanAmount) || loanAmount <= 0) // Validation of loan amount input
        {
            Console.WriteLine("Invalid amount. Please enter a valid loan amount:\n"); // Prompts user again if input is invalid
            loanAmountInput = Console.ReadLine()!; // Reads loan amount user inputs again while not decimal or less than equal to 0
        }

        Console.WriteLine("Please enter the loan term between 3-10 years:\n"); // Prompts user for loan term
        string loanTermInput = Console.ReadLine()!; // Reads loan term user inputs
        int loanTerm; // Variable to store parsed loan term

        while (!int.TryParse(loanTermInput, out loanTerm) || loanTerm < 3 || loanTerm > 10) // Validation of loan term input
        {
            Console.WriteLine("Invalid term. Please enter a valid loan term between 3-10 years:\n"); // Prompts user again if input is invalid
            loanTermInput = Console.ReadLine()!; // Reads loan term user inputs again while not int or less than 3 or greater than 10
        }

        Console.WriteLine($"Thank you, {username}. Your application for a loan of {loanAmount:C} over a term of {loanTerm} years has been received.\n"); // Acknowledges recieval of loan application
        Console.WriteLine("Our team will review your application and get back to you shortly.\n"); // Informs user of review process
    }
}
