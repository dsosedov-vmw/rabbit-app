using System.Text;
using RabbitMQ.Client;

namespace RMQApp.Web
{
    public sealed class QueueConnector
    {
        const string QueueName = "rq";

        private static QueueConnector instance = null;
        private static readonly object @lock = new object();

        readonly IConnection _connection;
        readonly IModel _channel;

        QueueConnector()
        {
            var factory = new ConnectionFactory() { HostName = "192.168.64.29", Port = 31672 };

            _connection = factory.CreateConnection(nameof(RMQApp));

            _channel = _connection.CreateModel();

            _channel.QueueDeclare(QueueName, false, false, false, null);
        }

        ~QueueConnector()
        {
            _channel.Dispose();
            _connection.Dispose();
        }

        public bool IsOpen()
        {
            return _channel.IsOpen;
        }

        public void Publish(string message)
        {
            _channel.BasicPublish("", QueueName, null, Encoding.UTF8.GetBytes(message));
        }

        public static QueueConnector Instance
        {
            get
            {
                lock (@lock)
                {
                    if (instance == null)
                    {
                        instance = new QueueConnector();
                    }

                    return instance;
                }
            }
        }
    }
}
