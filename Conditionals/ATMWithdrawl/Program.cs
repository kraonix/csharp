class ATMWithdrawl
{
    public static void Main(String [] args)
    {
        int pin = 1234;
        int bal = 10000;


        bool cardInserted = false;

        Console.Write("Is card inserted (true/false): ");
        cardInserted = bool.Parse(Console.ReadLine());

        int enteredPin, withdrawlAmount;
        Console.Write("Enter PIN: ");
        enteredPin = int.Parse(Console.ReadLine());

        if(cardInserted)
        {
            if(enteredPin == pin)
            {
                Console.Write("Enter Withdrawl Amount: ");
                withdrawlAmount = int.Parse(Console.ReadLine());

                if(withdrawlAmount <= bal)
                {
                    bal -= withdrawlAmount;
                    Console.WriteLine("Please collect your cash.");
                    Console.WriteLine($"Remaining Balance: {bal}");
                }
                else
                {
                    Console.WriteLine("Insufficient Balance.");
                }
            }
            else
            {
                Console.WriteLine("Incorrect PIN.");
            }
        }
        else
        {
            Console.WriteLine("Please insert your card.");
        }
    }
}