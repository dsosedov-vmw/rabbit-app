using System;
using System.Text;
using RabbitMQ.Client;
using Steeltoe.CloudFoundry.Connector.RabbitMQ;

namespace RMQApp.Web
{
    public sealed class QueueConnector
    {
        const string QueueName = "rq";

        static QueueConnector instance = null;
        static readonly object @lock = new object();

        readonly IConnection _connection;
        readonly IModel _channel;

        QueueConnector()
        {
            var config = SteeltoeConfigurationManager.Instance.GetConfiguration();

            Console.WriteLine($"Rabbit: {config.GetSection("VCAP_SERVICES").Value}");

            //foreach (var child in config.GetChildren())
            //{
            //    Console.WriteLine($"Path: {child.Path}; Key: {child.Key}; Value: {child.Value}");
            //}

            var options = new RabbitMQProviderConnectorOptions(config.GetSection("VCAP_SERVICES"));

            Console.WriteLine($"Host: {options.Server}");

            var factory = new ConnectionFactory
            {
                HostName = "192.168.8.36"/*options.Server*/,
                Password = "uJeLxtEiYc8U3VzWUQC6K8dy7JjoMhqB"/*options.Password*/,
                Port = 5672/*options.Port*/,
                //Uri = new Uri("amqp://df76ef20-a5a5-462a-bdfb-10d1de440841:uJeLxtEiYc8U3VzWUQC6K8dy7JjoMhqB@192.168.8.36:5672/cf087b17-9714-4ec0-b7f9-4ecd6aadd593"/*options.Uri*/),
                UserName = "df76ef20-a5a5-462a-bdfb-10d1de440841"/*options.Username*/,
                VirtualHost = "cf087b17-9714-4ec0-b7f9-4ecd6aadd593"/*options.VirtualHost*/,
            };

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
