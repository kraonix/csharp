using Payment.AbstractEx;

class Program
{
    public static void Main(string[] args)
    {
        Payments payment = new UpiPayment(1500, "sachin123@upi"); // polymorphic behavior
        payment.Pay(); // call to implemented method
        payment.PrintReceipt(); // call to concrete method

        payment = new CardPayment(2500, "1234567890123456"); // polymorphic behavior
        payment.Pay(); // call to implemented method
        payment.PrintReceipt(); // call to concrete method
    }
}