class VowelOrConsonant
{
    static void Main(string[] args)
    {
        // Input a letter from the user
        Console.Write("Enter a letter: ");
        char letter = Char.ToLower(Console.ReadLine()[0]);

        // Determine if the letter is a vowel or consonant
        switch (letter)
        {
            // Vowel cases
            case 'a':
            case 'e':
            case 'i':
            case 'o':
            case 'u':
                Console.WriteLine($"{letter} is a Vowel.");
                break;
                
            // Consonant cases    
            default:
                if (letter >= 'a' && letter <= 'z')
                {
                    Console.WriteLine($"{letter} is a Consonant.");
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter an alphabet letter.");
                }
                break;
        }
    }
}