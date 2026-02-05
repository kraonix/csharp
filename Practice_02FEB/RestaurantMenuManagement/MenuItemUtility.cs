using System.Runtime.CompilerServices;

namespace RMM
{
    public class MenuItemUtility
    {
        //Collection of Menu Items
        private List<MenuItem> menuItem = new List<MenuItem>();

        // In class MenuManager:
        // Adds item with validation for price > 0
        public void AddMenuItem(string name, string category, double price, bool isVeg)
        {
            if (price > 0)
            {
                MenuItem item = new MenuItem()
                {
                    ItemName = name,
                    Category = category,
                    Price = price,
                    IsVegetarian = isVeg
                };
                menuItem.Add(item);
                Console.WriteLine("Item Added Successfully!");
            }
            else
            {
                Console.WriteLine("Price Cannot be 0 or Lesser");
            }
        }

        // Groups items by category
        public Dictionary<string, List<MenuItem>> GroupItemsByCategory()
        {
            Dictionary<string, List<MenuItem>> result = new Dictionary<string, List<MenuItem>>();

            foreach (var item in menuItem)
            {
                if (!result.ContainsKey(item.Category))
                    result[item.Category] = new List<MenuItem>();

                result[item.Category].Add(item);
            }

            return result;
        }

        // Returns all vegetarian items
        public List<MenuItem> GetVegetarianItems()
        {
            List<MenuItem> result = new List<MenuItem>();

            foreach (var item in menuItem)
            {
                if (item.IsVegetarian)
                {
                    result.Add(item);
                }
            }

            return result;
        }

        // Returns average price of items in category
        public double CalculateAveragePriceByCategory(string category)
        {
            double count = 0;
            double total = 0;
            double result = 0;

            foreach (var item in menuItem)
            {
                if (item.Category == category)
                {
                    count++;
                    total += item.Price;
                }
            }

            result = total / count;
            return result;
        }
    }
}