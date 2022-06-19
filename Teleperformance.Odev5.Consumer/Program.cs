using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

var connectioFactory = new ConnectionFactory()
{
    HostName = "localhost",
    VirtualHost = "/",
    Port = 5672,
    UserName = "guest",
    Password = "guest"
};

var connection = connectioFactory.CreateConnection();

var channel = connection.CreateModel();

var consumer = new EventingBasicConsumer(channel);

consumer.Received += (sender, args) =>
{

    var message = Encoding.UTF8.GetString(args.Body.ToArray());
    Console.WriteLine(message);
};

channel.BasicConsume("fanout.queue1", false, consumer);

