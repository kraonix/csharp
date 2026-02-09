public class ApplyDiscountCommand : ICommand
{
    private readonly Cart _cart;
    private readonly decimal _percentage;
    private decimal _previousDiscount;

    public ApplyDiscountCommand(Cart cart, decimal percentage)
    {
        _cart = cart;
        _percentage = percentage;
    }

    public void Execute()
    {
        _previousDiscount = _percentage; // simple model
        _cart.ApplyDiscount(_percentage);
    }

    public void Undo()
    {
        _cart.RemoveDiscount();
    }
}
