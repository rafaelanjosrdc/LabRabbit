using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Worker
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { Uri = new Uri("amqp://user:pass@localhost:5672/my_vhost") };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare("MinhaPrimeiraFila", true, false, false, null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += Consumer_Reiceved;

            channel.BasicConsume(queue: "MinhaPrimeiraFila",
                                autoAck: true,
                                consumer: consumer);

            Console.WriteLine("Eu sou um worker");
            Console.WriteLine("Preesione qualquer tecla para encerrar");
            Console.ReadLine();
        }

        private static void Consumer_Reiceved(object sender, BasicDeliverEventArgs ea)
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            Console.WriteLine("Lendo {0}", message);
        }
    }
}
