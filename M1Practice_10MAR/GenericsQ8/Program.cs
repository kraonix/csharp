using System; // Console

namespace ItTechGenie.M1.GenericsDelegates.Q8
{
    // `out T` means Producer is covariant (can be used as base type producer).
    public interface IProducer<out T>
    {
        T Produce(); // produce an item
    }

    // `in T` means Consumer is contravariant (can consume derived items).
    public interface IConsumer<in T>
    {
        void Consume(T item); // consume an item
    }

    public class Program
    {
        public static void Main()
        {
            IProducer<EmailMessage> emailProducer = new EmailMessageProducer();
            IProducer<Message> messageProducer = emailProducer;

            IConsumer<Message> messageConsumer = new MessageConsoleConsumer();
            IConsumer<EmailMessage> emailConsumer = messageConsumer;

            Pipeline.Transfer(emailProducer, messageConsumer);
        }
    }

    public static class Pipeline
    {
        // ✅ TODO: Student must implement only this method
        public static void Transfer<T>(IProducer<T> producer, IConsumer<T> consumer)
        {
            // TODO:
            // 1) produce item using producer.Produce()
            // 2) pass it to consumer.Consume(item)
            var item = producer.Produce();
            consumer.Consume(item);
        }
    }

    public class Message
    {
        public string Text { get; }
        public Message(string text) => Text = text; // assign text
    }

    public class EmailMessage : Message
    {
        public string To { get; }
        public EmailMessage(string to, string text) : base(text) => To = to; // assign
    }

    public class EmailMessageProducer : IProducer<EmailMessage>
    {
        public EmailMessage Produce() => new EmailMessage("team@ittechgenie.com", "Welcome email"); // sample
    }

    public class MessageConsoleConsumer : IConsumer<Message>
    {
        public void Consume(Message item) => Console.WriteLine($"Consumed: {item.Text}"); // output
    }
}