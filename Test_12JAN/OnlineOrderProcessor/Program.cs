using Models;
using Data;
using Logic;
using Notifications;

class Program
{
    static CustomerNotification customerNotify = new();
    static LogisticsNotification logisticsNotify = new();

    static void Main()
    {
        SeedInitialOrders();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("====== ONLINE ORDER PROCESSOR ======");
            Console.WriteLine("1. View Products");
            Console.WriteLine("2. View Customers");
            Console.WriteLine("3. Add Customer");
            Console.WriteLine("4. Create New Order");
            Console.WriteLine("5. Change Order Status");
            Console.WriteLine("6. View All Orders Report");
            Console.WriteLine("0. Exit");
            Console.Write("Choose option: ");

            switch (Console.ReadLine())
            {
                case "1": ShowProducts(); break;
                case "2": ShowCustomers(); break;
                case "3": AddCustomer(); break;
                case "4": CreateOrder(); break;
                case "5": ChangeOrderStatus(); break;
                case "6": PrintOrderReport(); break;
                case "0": return;
                default: Console.WriteLine("Invalid option"); Pause(); break;
            }
        }
    }

    // ---------------- MENU ACTIONS ----------------

    static void ShowProducts()
    {
        Console.WriteLine("\nProducts:");
        foreach (var p in ProductData.Products)
            Console.WriteLine($"{p.Id}. {p.Name} - ₹{p.Price}");

        Pause();
    }

    static void ShowCustomers()
    {
        Console.WriteLine("\nCustomers:");
        foreach (var c in CustomerData.Customers)
            Console.WriteLine($"{c.Id}. {c.Name}");

        Pause();
    }

    static void AddCustomer()
    {
        Console.Write("Enter customer name: ");
        string name = Console.ReadLine()!;

        int id = CustomerData.GetNextId();
        CustomerData.AddCustomer(id, name);

        Console.WriteLine("Customer added successfully.");
        Pause();
    }

    static void CreateOrder()
    {
        ShowCustomers();
        Console.Write("Select Customer ID: ");
        int customerId = int.Parse(Console.ReadLine()!);

        var customer = CustomerData.GetById(customerId);
        if (customer == null)
        {
            Console.WriteLine("Invalid customer.");
            Pause();
            return;
        }

        int orderId = OrderData.GetNextOrderId();
        var order = new Order(orderId, customer);

        AttachNotifications(order);

        while (true)
        {
            ShowProducts();
            Console.Write("Enter Product ID to add (0 to finish): ");
            int pid = int.Parse(Console.ReadLine()!);

            if (pid == 0) break;

            var product = ProductData.GetById(pid);
            if (product == null)
            {
                Console.WriteLine("Invalid product.");
                continue;
            }

            Console.Write("Enter quantity: ");
            int qty = int.Parse(Console.ReadLine()!);

            order.AddItem(product, qty);
            Console.WriteLine("Item added.");
        }

        OrderData.AddOrder(order);
        Console.WriteLine($"Order {order.Id} created successfully.");
        Pause();
    }

    static void ChangeOrderStatus()
    {
        Console.Write("Enter Order ID: ");
        int id = int.Parse(Console.ReadLine()!);

        var order = OrderData.GetById(id);
        if (order == null)
        {
            Console.WriteLine("Order not found.");
            Pause();
            return;
        }

        Console.WriteLine("Select New Status:");
        foreach (var s in Enum.GetValues<OrderStatus>())
            Console.WriteLine($"{(int)s}. {s}");

        int status = int.Parse(Console.ReadLine()!);
        order.ChangeStatus((OrderStatus)status);

        Pause();
    }

    static void PrintOrderReport()
    {
        Console.WriteLine("\n========= ORDER REPORT =========\n");

        foreach (var o in OrderData.GetAll())
        {
            Console.WriteLine($"Order ID: {o.Id}");
            Console.WriteLine($"Customer: {o.Customer.Name}");
            Console.WriteLine($"Status: {o.CurrentStatus}");

            Console.WriteLine("Items:");
            foreach (var i in o.Items)
                Console.WriteLine($" - {i.Product.Name} x{i.Quantity} = ₹{i.Total}");

            Console.WriteLine($"Total: ₹{o.CalculateTotal()}");

            Console.WriteLine("Timeline:");
            foreach (var h in o.History)
                Console.WriteLine($"  {h.TimeStamp:T} : {h.OldStatus} → {h.NewStatus}");

            Console.WriteLine("--------------------------------");
        }

        Pause();
    }

    // ---------------- HELPERS ----------------

    static void AttachNotifications(Order order)
    {
        order.StatusChanged += customerNotify.Notify;
        order.StatusChanged += logisticsNotify.Notify;
    }

    static void Pause()
    {
        Console.WriteLine("\nPress Enter to continue...");
        Console.ReadLine();
    }

    static void SeedInitialOrders()
    {
        var o1 = OrderFactory.CreateSampleOrder(101, 1);
        AttachNotifications(o1);
        OrderData.AddOrder(o1);
    }
}
