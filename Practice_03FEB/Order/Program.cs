using System;

class OrderProcessor
{
    static void Main()
    {
        int[] orders = { 101, -1, 103 };

        foreach (var order in orders)
        {
            try
            {
                if (order <= 0)
                    throw new Exception("Invalid order ID");

                Console.WriteLine($"Order {order} processed");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
