using RabbitMQ.Client;
using System.Text;

var factory = new ConnectionFactory()
{
    HostName = "localhost"
};

using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

// Create queue
channel.QueueDeclare(
    queue: "demo_queue",
    durable: false,
    exclusive: false,
    autoDelete: false,
    arguments: null
);

Console.WriteLine("🚀 Producer is running...");
Console.WriteLine("Type message and press Enter (type 'exit' to stop)");

while (true)
{
    var message = Console.ReadLine();

    if (message?.ToLower() == "exit")
        break;

    var body = Encoding.UTF8.GetBytes(message);

    channel.BasicPublish(
        exchange: "",
        routingKey: "demo_queue",
        basicProperties: null,
        body: body
    );

    Console.WriteLine("✅ Sent!");
}