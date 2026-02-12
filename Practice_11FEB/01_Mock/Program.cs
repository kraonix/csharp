public class Jewellery
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public int Price { get; set; }
}

public class JewelleryUtility
{
    public void GetJewelleryDetails(Jewellery jewel)
    {
        Console.WriteLine($"Details: {jewel.Id} {jewel.Name} {jewel.Price}");
    }

    public void UpdateJewelleryPrice(Jewellery jewel, int newPrice)
    {
        jewel.Price = newPrice;
        Console.WriteLine($"Price Updated: {jewel.Price}");
    }
}

public class Program
{
    public static List<string> splitter(string input)
    {
        // List<string> result = new List<string>();
        // string temp = "";
        // foreach (var c in input)
        // {
        //     if (c != ' ')
        //     {
        //         temp += c;
        //     }
        //     else
        //     {
        //         result.Add(temp);
        //         temp = "";
        //     }
        // }

        // if (temp != "")
        // result.Add(temp);

        // return result;

        return input.Split(' ').ToList();
    }
    public static void Main(string[] args)
    {
        string input = Console.ReadLine();

        List<string> inputs = splitter(input);

        Jewellery jewel = new Jewellery
        {
            Id = inputs[0],
            Name = inputs[1],
            Price = int.Parse(inputs[2])
        };

        JewelleryUtility util = new JewelleryUtility();

        string choice = "";
        do
        {
            choice = Console.ReadLine();
            int updatePrice = 0;
            if (choice.Length > 1)
            {
                List<string> choices = splitter(choice);
                choice = choices[0];
                updatePrice = int.Parse(choices[1]);
            }

            switch (choice)
            {
                case "1":
                    util.GetJewelleryDetails(jewel);
                    break;
                case "2":
                    util.UpdateJewelleryPrice(jewel, updatePrice);
                    break;
                case "3":
                    Console.WriteLine("Thank You");
                    break;
            }
        }while(choice != "3");
    }
}