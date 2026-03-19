using System.Text;
using System.Text.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Shared.Models;

namespace CartApi.Services;

public class CartConsumerService : BackgroundService
{
    private readonly InMemoryCartStore _cartStore;
    private readonly ILogger<CartConsumerService> _logger;
    private IConnection? _connection;
    private IModel? _channel;

    public const string CartQueue = "cart_queue";

    public CartConsumerService(InMemoryCartStore cartStore, ILogger<CartConsumerService> logger)
    {
        _cartStore = cartStore;
        _logger = logger;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        stoppingToken.ThrowIfCancellationRequested();

        try
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost",
                Port = 5672,
                UserName = "guest",
                Password = "guest"
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.QueueDeclare(queue: CartQueue, durable: false, exclusive: false, autoDelete: false, arguments: null);

            _logger.LogInformation("[CartConsumer] Connected to RabbitMQ. Listening on '{Queue}'...", CartQueue);

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (_, ea) =>
            {
                try
                {
                    var body = ea.Body.ToArray();
                    var json = Encoding.UTF8.GetString(body);
                    _logger.LogInformation("[CartConsumer] Received message: {Json}", json);

                    var cartMessage = JsonSerializer.Deserialize<CartMessage>(json);
                    if (cartMessage != null)
                    {
                        var cartItem = new CartItem
                        {
                            ProductId = cartMessage.ProductId,
                            ProductName = cartMessage.ProductName,
                            Price = cartMessage.Price,
                            Quantity = 1
                        };
                        _cartStore.AddOrUpdate(cartItem);
                        _logger.LogInformation("[CartConsumer] Cart updated: Product {Id} '{Name}' at ₹{Price}",
                            cartItem.ProductId, cartItem.ProductName, cartItem.Price);
                    }

                    _channel.BasicAck(ea.DeliveryTag, false);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "[CartConsumer] Error processing cart message.");
                    _channel.BasicNack(ea.DeliveryTag, false, false);
                }
            };

            _channel.BasicConsume(queue: CartQueue, autoAck: false, consumer: consumer);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "[CartConsumer] Failed to connect to RabbitMQ. Cart queue will not be consumed.");
        }

        return Task.CompletedTask;
    }

    public override void Dispose()
    {
        _channel?.Close();
        _connection?.Close();
        base.Dispose();
    }
}
