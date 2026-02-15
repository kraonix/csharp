using System;

namespace BookStoreApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            // TODO:
            // 1. Read initial input
            // Format: BookID Title Price Stock
            string input = Console.ReadLine();
            var inputList = input.Split(' ').ToList();

            Book book = new Book
            {
                Id = inputList[0],
                Title = inputList[1],
                Price = int.Parse(inputList[2]),
                Stock = int.Parse(inputList[3])
            };

            BookUtility utility = new BookUtility(book);

            while (true)
            {
                // TODO:
                // Display menu:
                // 1 -> Display book details
                // 2 -> Update book price
                // 3 -> Update book stock
                // 4 -> Exit
                Console.WriteLine("1 -> Display book details");
                Console.WriteLine("2 -> Update book price");
                Console.WriteLine("3 -> Update book stock");
                Console.WriteLine("4 -> Exit");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        utility.GetBookDetails();
                        break;

                    case 2:
                        // TODO:
                        // Read new price
                        // Call UpdateBookPrice()
                        int newPrice = int.Parse(Console.ReadLine());
                        utility.UpdateBookPrice(newPrice);
                        break;

                    case 3:
                        // TODO:
                        // Read new stock
                        // Call UpdateBookStock()
                        int newStock = int.Parse(Console.ReadLine());
                        utility.UpdateBookStock(newStock);
                        break;

                    case 4:
                        Console.WriteLine("Thank You");
                        return;

                    default:
                        // TODO: Handle invalid choice
                        Console.WriteLine("Select a Valid Option!");
                        break;
                }
            }
        }
    }
}
