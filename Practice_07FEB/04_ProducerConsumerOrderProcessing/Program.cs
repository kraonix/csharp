using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public class Order
{
    public int OrderId { get; set; }
}

public class OrderProcessor
{
    private readonly BlockingCollection<Order> _queue =
        new BlockingCollection<Order>();

    private int _processedCount = 0;

    public async Task<int> StartProcessingAsync()
    {
        // Start producer
        var producerTask = Task.Run(() => ProduceOrders());

        // Start 3 consumers
        var consumers = new List<Task>
        {
            Task.Run(() => ConsumeOrders(1)),
            Task.Run(() => ConsumeOrders(2)),
            Task.Run(() => ConsumeOrders(3))
        };

        // Wait for producer to finish
        await producerTask;

        // Signal no more items will be added
        _queue.CompleteAdding();

        // Wait for consumers to finish
        await Task.WhenAll(consumers);

        return _processedCount;
    }

    private void ProduceOrders()
    {
        for (int i = 1; i <= 10; i++)
        {
            var order = new Order { OrderId = i };
            Console.WriteLine($"Produced Order {i}");
            _queue.Add(order);
            Thread.Sleep(300); // simulate incoming orders
        }
    }

    private void ConsumeOrders(int workerId)
    {
        foreach (var order in _queue.GetConsumingEnumerable())
        {
            Console.WriteLine($"Worker {workerId} processing Order {order.OrderId}");

            Thread.Sleep(1000); // simulate processing delay

            Interlocked.Increment(ref _processedCount);
        }

        Console.WriteLine($"Worker {workerId} exiting.");
    }
}

class Program
{
    static async Task Main()
    {
        var processor = new OrderProcessor();

        int total = await processor.StartProcessingAsync();

        Console.WriteLine($"\nTotal Processed Orders: {total}");
    }
}
