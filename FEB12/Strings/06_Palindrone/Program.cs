class Program
{
    static bool IsPalindrome(string input)
    {
        int left = 0;
        int right = input.Length - 1;
        
        while (left < right)
        {
            if (input[left] != input[right])
                return false;
            
            left++;
            right--;
        }
        return true;
    }

    static void Main()
    {
        string input = Console.ReadLine();
        Console.WriteLine(IsPalindrome(input));
    }
}
