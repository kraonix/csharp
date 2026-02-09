class Program
{
    static void Main()
    {
        var cart = new Cart();
        var manager = new CommandManager();

        manager.ExecuteCommand(new AddItemCommand(cart, "Laptop"));
        manager.ExecuteCommand(new AddItemCommand(cart, "Mouse"));
        manager.ExecuteCommand(new ApplyDiscountCommand(cart, 10));

        cart.Print();

        Console.WriteLine("Undo last action...");
        manager.Undo();
        cart.Print();

        Console.WriteLine("Undo again...");
        manager.Undo();
        cart.Print();

        Console.WriteLine("Redo...");
        manager.Redo();
        cart.Print();
    }
}
