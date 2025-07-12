using Confluent.Kafka;

Console.WriteLine("🔹 Chat Consumer Listening...");
var config = new ConsumerConfig
{
    BootstrapServers = "localhost:9092",
    GroupId = "chat-group-1",
    AutoOffsetReset = AutoOffsetReset.Earliest
};

using var consumer = new ConsumerBuilder<Ignore, string>(config).Build();
consumer.Subscribe("chat-room");

try
{
    while (true)
    {
        var cr = consumer.Consume();
        Console.WriteLine($"👤 Friend: {cr.Message.Value}");
    }
}
catch (OperationCanceledException) { consumer.Close(); }
