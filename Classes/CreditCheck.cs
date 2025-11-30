public class CreditCheck 
{
    string username = LoginClass.storedUsername; // Get the logged-in username
    int creditRating = Random.Shared.Next(0, 1201); // Generates a random credit score between 0 and 1200

        public void CreditScore() // Method to display credit score
    {
        Console.WriteLine($"Welcome to your credit score assessment {username}!\n"); // Welcomes user to credit score assessment
        
        if (creditRating >= 0 && creditRating <= 459) // Determines credit rating based on score
        {
            Console.WriteLine($"Your credit score is {creditRating}. You have below average credit rating!\n"); // Displays credit score and rating
        }
        else if (creditRating >= 460 && creditRating <= 660) // Determines credit rating based on score
        {
            Console.WriteLine($"Your credit score is {creditRating}. You have average credit.\n"); // Displays credit score and rating
        }
        else if (creditRating >= 661 && creditRating <= 734) // Determines credit rating based on score
        {
            Console.WriteLine($"Your credit score is {creditRating}. You have good credit.\n"); // Displays credit score and rating
        }
        else if (creditRating >= 735 && creditRating <= 852) // Determines credit rating based on score
        {
            Console.WriteLine($"Your credit score is {creditRating}. You have very good credit.\n"); // Displays credit score and rating
        }
        else if (creditRating >= 853 && creditRating <= 1200) // Determines credit rating based on score
        {
            Console.WriteLine($"Your credit score is {creditRating}. You have excellent credit!\n"); // Displays credit score and rating
        }
    }
}
