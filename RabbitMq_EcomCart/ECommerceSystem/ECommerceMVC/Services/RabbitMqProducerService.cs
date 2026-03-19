using System.Text;
using System.Text.Json;
using RabbitMQ.Client;

namespace ECommerceMVC.Services;

public class RabbitMqProducerService : IDisposable
{
    private readonly IConnection _connection;
    private readonly IModel _channel;
    private readonly ILogger<RabbitMqProducerService> _logger;

    public const string CartQueue = "cart_queue";
    public const string PaymentQueue = "payment_queue";

    public RabbitMqProducerService(ILogger<RabbitMqProducerService> logger)
    {
        _logger = logger;
        try
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost",
                Port = 5672,
                UserName = "guest",
                Password = "guest",
                DispatchConsumersAsync = false
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            // Declare queues before use
            _channel.QueueDeclare(queue: CartQueue, durable: false, exclusive: false, autoDelete: false, arguments: null);
            _channel.QueueDeclare(queue: PaymentQueue, durable: false, exclusive: false, autoDelete: false, arguments: null);

            _logger.LogInformation("RabbitMQ Producer connected. Queues '{CartQueue}' and '{PaymentQueue}' declared.", CartQueue, PaymentQueue);
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Failed to connect to RabbitMQ on startup. Messages will not be sent.");
        }
    }

    public void PublishToQueue<T>(string queueName, T message)
    {
        if (_channel == null)
        {
            _logger.LogWarning("Cannot publish message to '{Queue}' because RabbitMQ is not connected.", queueName);
            return;
        }

        var json = JsonSerializer.Serialize(message);
        var body = Encoding.UTF8.GetBytes(json);

        var props = _channel.CreateBasicProperties();
        props.ContentType = "application/json";
        props.DeliveryMode = 2; // persistent

        _channel.BasicPublish(exchange: string.Empty, routingKey: queueName, basicProperties: props, body: body);
        _logger.LogInformation("[Producer] Published to '{Queue}': {Message}", queueName, json);
    }

    public void Dispose()
    {
        _channel?.Close();
        _connection?.Close();
    }
}
