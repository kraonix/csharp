using ProducerApi.Models;
using ProducerApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<RabbitMqOptions>(
    builder.Configuration.GetSection(RabbitMqOptions.SectionName));

builder.Services.AddSingleton<RabbitMqPublisher>();

// ✅ Swagger (same as Consumer)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ✅ Enable Swagger UI
app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () => Results.Ok(new
{
    service = "Producer API",
    description = "Publishes messages to RabbitMQ so the Consumer API can receive them."
}));

app.MapPost("/messages", (PublishMessageRequest request, RabbitMqPublisher publisher) =>
{
    if (string.IsNullOrWhiteSpace(request.Sender) || string.IsNullOrWhiteSpace(request.Text))
    {
        return Results.ValidationProblem(new Dictionary<string, string[]>
        {
            ["message"] = new[] { "Sender and Text are required." }
        });
    }

    var publishedMessage = publisher.Publish(request);
    return Results.Accepted($"/messages/{publishedMessage.Id}", publishedMessage);
})
.WithName("PublishMessage");

app.Run();