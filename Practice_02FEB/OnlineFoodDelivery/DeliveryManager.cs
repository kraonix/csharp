public class DeliveryManager
{
    private readonly List<Restaurant> _restaurants = new();
    private readonly List<FoodItem> _foodItems = new();
    private readonly List<Order> _orders = new();

    private int _restaurantIdCounter = 1;
    private int _foodItemIdCounter = 1;
    private int _orderIdCounter = 1;

    // Add Restaurant
    public void AddRestaurant(string name, string cuisine,
                              string location, double charge)
    {
        _restaurants.Add(new Restaurant
        {
            RestaurantId = _restaurantIdCounter++,
            Name = name,
            CuisineType = cuisine,
            Location = location,
            DeliveryCharge = charge
        });
    }

    // Add Food Item
    public void AddFoodItem(int restaurantId, string name,
                            string category, double price)
    {
        if (!_restaurants.Any(r => r.RestaurantId == restaurantId))
            throw new Exception("Restaurant not found");

        _foodItems.Add(new FoodItem
        {
            ItemId = _foodItemIdCounter++,
            Name = name,
            Category = category,
            Price = price,
            RestaurantId = restaurantId
        });
    }

    // Group Restaurants by Cuisine
    public Dictionary<string, List<Restaurant>> GroupRestaurantsByCuisine()
    {
        return _restaurants
            .GroupBy(r => r.CuisineType)
            .ToDictionary(g => g.Key, g => g.ToList());
    }

    // Place Order
    public bool PlaceOrder(int customerId, List<int> itemIds)
    {
        var items = _foodItems
            .Where(f => itemIds.Contains(f.ItemId))
            .ToList();

        if (!items.Any())
            return false;

        var restaurant = _restaurants
            .First(r => r.RestaurantId == items.First().RestaurantId);

        double total = items.Sum(i => i.Price) + restaurant.DeliveryCharge;

        _orders.Add(new Order
        {
            OrderId = _orderIdCounter++,
            CustomerId = customerId,
            Items = items,
            OrderTime = DateTime.Now,
            Status = "Pending",
            TotalAmount = total
        });

        return true;
    }

    // Get Pending Orders
    public List<Order> GetPendingOrders()
    {
        return _orders
            .Where(o => o.Status == "Pending")
            .ToList();
    }
}
