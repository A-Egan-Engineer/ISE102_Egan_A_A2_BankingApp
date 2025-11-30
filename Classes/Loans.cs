using System.Security.Cryptography.X509Certificates;

public class Loans : CreditCheck // Inherits from CreditCheck to access credit score functionalities
{
    bool creditChecked = false; // Boolean to track if credit score has been checked
    public void LoanWelcome()
    {
        Console.WriteLine("Welcome to the Loan Portal!\n"); // Welcomes user to loan portal

        Console.WriteLine("Please select one of the following options:\n"); // Prompts user to select an option
        Console.WriteLine("1. Check Credit Score\n"); // Prompts user to check credit score
        Console.WriteLine("2. Apply for a Loan\n"); // Prompts user to apply for a loan
        Console.WriteLine("3. Exit\n"); // Prompts user to exit

        string option = Console.ReadLine()!; // Reads user input for option selection

        switch (option) // Switch case to handle user selection
        {
            case "1":
                CreditCheck creditCheck = new CreditCheck(); // Create instance of CreditCheck class
                creditCheck.CreditScore(); // Call CreditScore method
                creditChecked = true; // Sets creditChecked to true after checking credit score
                break;
            case "2":
            if (!creditChecked) // Checks if credit score has been checked
                {
                    Console.WriteLine("Please check your credit score before applying for a loan.\n"); // Prompts user to check credit score first
                    return; // Exit if credit score is not checked
                }
                else
                {
                    LoanApplication loanApplication = new LoanApplication(); // Create instance of LoanApplication class
                    loanApplication.ApplyForLoan(); // Call ApplyForLoan method
                }
                break;
            case "3":
                Console.WriteLine("Thank you for using the Loan Management System. Goodbye!\n"); // Exit message is user selects exit
                break;
            default:
                Console.WriteLine("Invalid option selected. Please try again.\n"); // Handles invalid inputs and prompts user to try again
                break;
        }
    }
}