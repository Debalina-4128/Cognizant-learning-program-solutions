using Confluent.Kafka;

Console.WriteLine("🔹 Chat Producer Started");
var config = new ProducerConfig { BootstrapServers = "127.0.0.1:9092" };

using var producer = new ProducerBuilder<Null, string>(config).Build();

while (true)
{
    Console.Write("You: ");
    var message = Console.ReadLine();

    if (message?.ToLower() == "exit")
        break;

    await producer.ProduceAsync("chat-room", new Message<Null, string> { Value = message });
}
