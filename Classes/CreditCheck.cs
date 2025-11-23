class CreditCheck : SignUpClass
{
        public void CreditRating()
    {
        Console.WriteLine($"Welcome to your credit report {username}!\n");
        
        Random rand = new Random();
        int creditScore = rand.Next(0,1200);

        if (creditScore == 0 && creditScore <= 459)
        {
            Console.WriteLine($"Your credit score is {creditScore}. You have below average credit rating!");
        }
        else if (creditScore >= 460 && creditScore <= 660)
        {
            Console.WriteLine($"Your credit score is {creditScore}. You have average credit.");
        }
        else if (creditScore >= 661 && creditScore <= 734)
        {
            Console.WriteLine($"Your credit score is {creditScore}. You have good credit.");
        }
        else if (creditScore >= 735 && creditScore <= 852)
        {
            Console.WriteLine($"Your credit score is {creditScore}. You have very good credit.");
        }
        else if (creditScore >= 853 && creditScore <= 1200)
        {
            Console.WriteLine($"Your credit score is {creditScore}. You have excellent credit!");
        }
    }
}