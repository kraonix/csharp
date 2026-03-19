using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Options;
using ProducerApi.Models;
using RabbitMQ.Client;

namespace ProducerApi.Services;

public sealed class RabbitMqPublisher : IDisposable
{
    private IConnection? _connection;
    private IModel? _channel;
    private readonly RabbitMqOptions _options;

    public RabbitMqPublisher(IOptions<RabbitMqOptions> options)
    {
        _options = options.Value;
    }

    private void EnsureConnection()
    {
        if (_connection != null && _connection.IsOpen)
            return;

        try
        {
            Console.WriteLine("Connecting to RabbitMQ...");

            var factory = new ConnectionFactory
            {
                HostName = _options.HostName,
                Port = _options.Port,
                UserName = _options.UserName,
                Password = _options.Password
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.ExchangeDeclare(_options.ExchangeName, ExchangeType.Direct, durable: true);
            _channel.QueueDeclare(_options.QueueName, durable: true, exclusive: false, autoDelete: false);
            _channel.QueueBind(_options.QueueName, _options.ExchangeName, _options.RoutingKey);

            Console.WriteLine("RabbitMQ connected ✅");
        }
        catch (Exception ex)
        {
            Console.WriteLine("RABBIT INIT ERROR: " + ex.ToString());
            throw;
        }
    }

    public RabbitMessage Publish(PublishMessageRequest request)
    {
        try
        {
            EnsureConnection(); // 🔥 key fix

            var message = new RabbitMessage(
                Guid.NewGuid(),
                request.Sender.Trim(),
                request.Text.Trim(),
                DateTimeOffset.UtcNow);

            var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));

            var properties = _channel!.CreateBasicProperties();
            properties.Persistent = true;
            properties.ContentType = "application/json";

            _channel.BasicPublish(
                exchange: _options.ExchangeName,
                routingKey: _options.RoutingKey,
                basicProperties: properties,
                body: body);

            Console.WriteLine("Message sent 🚀");

            return message;
        }
        catch (Exception ex)
        {
            Console.WriteLine("PUBLISH ERROR: " + ex.ToString());
            throw;
        }
    }

    public void Dispose()
    {
        _channel?.Dispose();
        _connection?.Dispose();
    }
}