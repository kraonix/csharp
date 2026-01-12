using Models;
using Services;
using Logic;

namespace Data
{
    public static class OrderFactory
    {
        public static Order CreateSampleOrder(int orderId, int customerId)
        {
            var customer = CustomerData.GetById(customerId)!;

            var order = new Order(orderId, customer);

            order.AddItem(ProductData.GetById(1)!, 1);
            order.AddItem(ProductData.GetById(2)!, 2);

            return order;
        }
    }
}