using System;
using RabbitMQ.Client;
using System.Text;

namespace Sender
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { Uri = new Uri("amqp://user:pass@localhost:5672/my_vhost") };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare("MinhaPrimeiraFila", true, false, false, null);

            Console.WriteLine("Olá eu sou o cara q envia mensages!");
            Console.WriteLine("Preesione CTRL+C em qualquer momento, para encerrar!");
            while (true)
            {
                string message = Console.ReadLine();

                if (int.TryParse(message, out int number))
                {
                    for (int i = 0; i < number; i++)
                    {
                        SendMessage(channel, $"Mensagem automática {i + 1}");
                    }
                    Console.WriteLine($"{number} mensages enviadas");
                }

                SendMessage(channel, message);
            }
        }

        private static void SendMessage(IModel channel, string message)
        {
            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish("", "MinhaPrimeiraFila", null, body);
        }
    }
}
