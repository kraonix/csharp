class Program
{
    static void Main(string[] args)
    {
        System.Console.WriteLine("Welcome to Rock, Paper, Scissors Game!");
        System.Console.WriteLine("Enter your choice (rock, paper, scissors): ");
        string userChoice = System.Console.ReadLine().ToLower();

        string[] choices = { "rock", "paper", "scissors" };
        Random random = new Random();
        string computerChoice = choices[random.Next(choices.Length)];

        System.Console.WriteLine("Computer chose: " + computerChoice);

        if (userChoice == computerChoice)
        {
            System.Console.WriteLine("It's a tie!");
        }
        else if ((userChoice == "rock" && computerChoice == "scissors") ||
                 (userChoice == "paper" && computerChoice == "rock") ||
                 (userChoice == "scissors" && computerChoice == "paper"))
        {
            System.Console.WriteLine("You win!");
        }
        else
        {
            System.Console.WriteLine("Computer wins!");
        }
    }
}