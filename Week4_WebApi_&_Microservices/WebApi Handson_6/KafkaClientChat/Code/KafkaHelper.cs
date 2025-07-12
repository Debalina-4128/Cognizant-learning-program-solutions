using Confluent.Kafka;
using System;
using System.Threading;
using System.Threading.Tasks;

public class KafkaHelper
{
    private readonly string _topic = "chat-room";
    private readonly string _bootstrapServers = "127.0.0.1:9092";
    private IProducer<Null, string> _producer;

    public KafkaHelper()
    {
        var config = new ProducerConfig { BootstrapServers = _bootstrapServers };
        _producer = new ProducerBuilder<Null, string>(config).Build();
    }

    public async Task SendMessageAsync(string message)
    {
        await _producer.ProduceAsync(_topic, new Message<Null, string> { Value = message });
    }

    public void StartConsuming(Action<string> onMessageReceived, CancellationToken cancellationToken)
    {
        Task.Run(() =>
        {
            var config = new ConsumerConfig
            {
                BootstrapServers = _bootstrapServers,
                GroupId = Guid.NewGuid().ToString(), // different for each client
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            using var consumer = new ConsumerBuilder<Ignore, string>(config).Build();
            consumer.Subscribe(_topic);

            try
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    var result = consumer.Consume(cancellationToken);
                    onMessageReceived?.Invoke(result.Message.Value);
                }
            }
            catch (OperationCanceledException) { }
            finally
            {
                consumer.Close();
            }
        }, cancellationToken);
    }
}
