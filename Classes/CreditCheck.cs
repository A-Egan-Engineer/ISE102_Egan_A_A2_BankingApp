public class CreditCheck : SignUpClass
{
    int creditScore = Random.Shared.Next(0, 1201);

        public void CreditScore()
    {
        Console.WriteLine($"Welcome to your credit score assessment {username}!\n");
        
        if (creditScore >= 0 && creditScore <= 459)
        {
            Console.WriteLine($"Your credit score is {creditScore}. You have below average credit rating!\n");
        }
        else if (creditScore >= 460 && creditScore <= 660)
        {
            Console.WriteLine($"Your credit score is {creditScore}. You have average credit.\n");
        }
        else if (creditScore >= 661 && creditScore <= 734)
        {
            Console.WriteLine($"Your credit score is {creditScore}. You have good credit.\n");
        }
        else if (creditScore >= 735 && creditScore <= 852)
        {
            Console.WriteLine($"Your credit score is {creditScore}. You have very good credit.\n");
        }
        else if (creditScore >= 853 && creditScore <= 1200)
        {
            Console.WriteLine($"Your credit score is {creditScore}. You have excellent credit!\n");
        }
    }
}
