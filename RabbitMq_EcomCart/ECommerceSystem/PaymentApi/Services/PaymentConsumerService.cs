using System.Text;
using System.Text.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Shared.Models;

namespace PaymentApi.Services;

public class PaymentConsumerService : BackgroundService
{
    private readonly InMemoryPaymentStore _paymentStore;
    private readonly ILogger<PaymentConsumerService> _logger;
    private IConnection? _connection;
    private IModel? _channel;

    public const string PaymentQueue = "payment_queue";

    public PaymentConsumerService(InMemoryPaymentStore paymentStore, ILogger<PaymentConsumerService> logger)
    {
        _paymentStore = paymentStore;
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

            _channel.QueueDeclare(queue: PaymentQueue, durable: false, exclusive: false, autoDelete: false, arguments: null);

            _logger.LogInformation("[PaymentConsumer] Connected to RabbitMQ. Listening on '{Queue}'...", PaymentQueue);

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (_, ea) =>
            {
                try
                {
                    var body = ea.Body.ToArray();
                    var json = Encoding.UTF8.GetString(body);
                    _logger.LogInformation("[PaymentConsumer] Received payment message: {Json}", json);

                    var paymentMessage = JsonSerializer.Deserialize<PaymentMessage>(json);
                    if (paymentMessage != null)
                    {
                        // Simulate payment processing delay
                        Thread.Sleep(500);

                        var record = new PaymentRecord
                        {
                            OrderId = paymentMessage.OrderId,
                            TotalAmount = paymentMessage.TotalAmount,
                            ProcessedAt = DateTime.UtcNow,
                            Status = "Success",
                            Items = paymentMessage.Items
                        };

                        _paymentStore.RecordPayment(record);

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"\n╔════════════════════════════════════════╗");
                        Console.WriteLine($"║  💰 PAYMENT PROCESSED SUCCESSFULLY!   ║");
                        Console.WriteLine($"╠════════════════════════════════════════╣");
                        Console.WriteLine($"║  Order ID   : {paymentMessage.OrderId,-24}║");
                        Console.WriteLine($"║  Amount     : ₹{paymentMessage.TotalAmount,-23}║");
                        Console.WriteLine($"║  Items      : {paymentMessage.Items.Count,-24}║");
                        Console.WriteLine($"║  Time       : {DateTime.UtcNow:HH:mm:ss UTC}               ║");
                        Console.WriteLine($"╚════════════════════════════════════════╝\n");
                        Console.ResetColor();

                        _logger.LogInformation("[PaymentConsumer] Payment SUCCESS for Order {OrderId}. Amount: ₹{Amount}",
                            paymentMessage.OrderId, paymentMessage.TotalAmount);
                    }

                    _channel.BasicAck(ea.DeliveryTag, false);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "[PaymentConsumer] Error processing payment message.");
                    _channel.BasicNack(ea.DeliveryTag, false, false);
                }
            };

            _channel.BasicConsume(queue: PaymentQueue, autoAck: false, consumer: consumer);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "[PaymentConsumer] Failed to connect to RabbitMQ. Payment queue will not be consumed.");
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
