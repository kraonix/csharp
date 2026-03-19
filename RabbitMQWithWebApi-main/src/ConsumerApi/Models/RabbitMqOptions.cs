namespace ConsumerApi.Models
{
    public class RabbitMqOptions
    {
        public const string SectionName = "RabbitMq";

        public string HostName { get; set; } = "localhost";
        public int Port { get; set; } = 5672;

        public string UserName { get; set; } = "guest";
        public string Password { get; set; } = "guest";

        public string QueueName { get; set; } = "test-queue";
        public string ExchangeName { get; set; } = "test-exchange";
        public string RoutingKey { get; set; } = "test-routing-key";
    }
}