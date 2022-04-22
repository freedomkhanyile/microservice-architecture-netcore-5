using RabbitMQ.Client;
using System;
using System.Text;

namespace Producer
{
    public class Sender
    {
        public static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using(var channel = connection.CreateModel())
            {
                channel.QueueDeclare("BasicTest", false, false, false, null);

                string message = "Getting up and running with RabbitMQ";
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish("", "BasicTest", null, body);

                Console.WriteLine("INFO: Message has been sent");
            }

            Console.WriteLine("INST: Press [Enter] to Exit sender App");
            Console.ReadLine();
        }
    }
}
