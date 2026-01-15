public class Program
{
    // A Sorted Dictionary
    public static SortedDictionary<string, long> ItemDetails = new SortedDictionary<string, long>();

    // Returns all item details for Provided SoldCount
    public static SortedDictionary<string, long> FindItemDetails(long SoldCount)
    {
        SortedDictionary<string, long> Result = new SortedDictionary<string, long>();

        foreach (var item in ItemDetails)
        {
            if (item.Value == SoldCount)
            {
                Result.Add(item.Key, item.Value);
            }
        }

        return Result;
    }


    // Returns min sold and max sold item names
    public static List<string> FindMinandMaxSoldItems()
    {
        long min = ItemDetails.Min(x => x.Value);
        long max = ItemDetails.Max(x => x.Value);

        string minItem = ItemDetails.First(x => x.Value == min).Key;
        string maxItem = ItemDetails.First(x => x.Value == max).Key;

        return new List<string> { minItem, maxItem };
    }

    // Sort items by sold count
    public static Dictionary<string, long> SortByCount()
    {
        return ItemDetails.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
    }

    public static void Main()
    {
        Console.Write("Enter Number of Items : ");
        int Total = int.Parse(Console.ReadLine());

        for (int i = 0; i < Total; i++)
        {
            Console.Write("Item Name: ");
            string Name = Console.ReadLine();
            Console.Write("Sold Amount: ");
            long Amount = long.Parse(Console.ReadLine());

            ItemDetails[Name] = Amount;
            Console.WriteLine();
        }

        Console.WriteLine("\n--- Item Details ---\n");

        Console.Write("Item(s) to Find: ");
        long SoldAmount = long.Parse(Console.ReadLine());
        var Find = FindItemDetails(SoldAmount);
        if (Find.Count == 0)
        {
            Console.WriteLine("Invalid Sold Count");
        }
        else
        {
            Console.WriteLine("Items Found: ");
            foreach (var item in Find)
            {
                Console.WriteLine($"{item.Key} : {item.Value}");
            }
        }

        var minMax = FindMinandMaxSoldItems();
        Console.WriteLine($"\nLeast Sold Item: {minMax[0]}");
        Console.WriteLine($"Most Sold Item: {minMax[1]}");

        Console.WriteLine("\n--- Sorted By Sold Count ---");
        foreach (var item in SortByCount())
        {
            Console.WriteLine($"{item.Key} : {item.Value}");
        }
    }
}
