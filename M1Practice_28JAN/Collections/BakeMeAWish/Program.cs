using System;
using System.Collections.Generic;

class CakeOrder
{
    private Dictionary<string, double> orderMap = new Dictionary<string, double>();

    // Getter
    public Dictionary<string, double> OrderMap
    {
        get { return orderMap; }
        set { orderMap = value; }
    }

    // Requirement 1
    public void addOrderDetails(string orderId, double cakeCost)
    {
        orderMap[orderId] = cakeCost;
    }

    // Requirement 2
    public Dictionary<string, double> findOrdersAboveSpecifiedCost(double cakeCost)
    {
        Dictionary<string, double> result = new Dictionary<string, double>();

        foreach (var entry in orderMap)
        {
            if (entry.Value > cakeCost)
            {
                result.Add(entry.Key, entry.Value);
            }
        }

        return result;
    }
}

class UserInterface
{
    public static void Main(string[] args)
    {
        CakeOrder cakeOrder = new CakeOrder();

        Console.WriteLine("Enter number of cake orders to be added");
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the cake order details (Order Id:CakeCost)");

        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine();
            string[] parts = input.Split(':');

            string orderId = parts[0];
            double cakeCost = double.Parse(parts[1]);

            cakeOrder.addOrderDetails(orderId, cakeCost);
        }

        Console.WriteLine("Enter the cake cost to find the orders above the specified cost");
        double searchCost = double.Parse(Console.ReadLine());

        Dictionary<string, double> filteredOrders =
            cakeOrder.findOrdersAboveSpecifiedCost(searchCost);

        if (filteredOrders.Count == 0)
        {
            Console.WriteLine("No cake orders found");
        }
        else
        {
            foreach (var entry in filteredOrders)
            {
                Console.WriteLine($"{entry.Key}:{entry.Value}");
            }
        }
    }
}
