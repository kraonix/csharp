namespace Payment.AbstractEx
{
    abstract class Payments
    {
        /// <summary>
        /// The amount to be paid.
        /// </summary>
        public decimal Amount { get; }
        protected Payments(decimal amount) => Amount = amount; // constructor

        public void PrintReceipt() // concrete method
        {
            Console.WriteLine($"Receipt: \nAmount = {Amount} \n"); // print receipt
        }

        public abstract void Pay(); // must be implemented
    }

    class UpiPayment : Payments
    {
        public string UpiId { get; }
        public UpiPayment(decimal amount, string upiId) : base(amount) => UpiId = upiId; // constructor

        public override void Pay() // implementation of abstract method
        {
            Console.WriteLine($"\nPaid {Amount} via UPI ({UpiId}).");
        }
    }

    class CardPayment : Payments
    {
        public string CardNumber { get; }
        public CardPayment(decimal amount, string cardNumber) : base(amount) => CardNumber = cardNumber; // constructor

        public override void Pay() // implementation of abstract method
        {
            Console.WriteLine($"\nPaid {Amount} via Card (**** **** **** {CardNumber[^4..]}).");
        }
    }
}