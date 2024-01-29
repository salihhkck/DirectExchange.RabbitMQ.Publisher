using RabbitMQ.Client;
using System.Text;

namespace DirectExchange.RabbitMQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Bağlantı Oluşturma RabbitMQ ile.
            ConnectionFactory connectionFactory = new();
            connectionFactory.Uri = new("amqps://rkjhqugu:ldW9uYt3EtaPRzn9_ulmFp657F27TyNA@jackal.rmq.cloudamqp.com/rkjhqugu");


            //Bağlantı aktifleştirme ve kanal açma
            using IConnection connection = connectionFactory.CreateConnection();
            using IModel channel = connection.CreateModel();

            channel.ExchangeDeclare(exchange: "direct-exchange-example", type: ExchangeType.Direct);

            while (true)
            {
                Console.WriteLine("Mesaj : ");
                string message=Console.ReadLine();
                byte[] byteMessage=Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(
                    exchange: "direct-exchange-example",
                    routingKey: "direct-exchange-example",
                    body:byteMessage);
            }

            Console.Read();
        }
    }
}
