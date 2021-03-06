using Microsoft.AspNetCore.Mvc;
using Teleperformance.Odev4.Services.Abstractions;
using RabbitMQ.Client;

namespace Teleperformance.Odev4.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService service;

        public UsersController(IUserService service)
        {
            this.service = service;
        }

        [HttpGet("list")]
        public IActionResult GetAllUsers() // Kullanıcıları listele
        {
            var result = service.GetAllUsers();
            return Ok(result);
        }

        [HttpGet("Pagedlist")]   //kullanıcıları sayfalama
        public IActionResult GetUsersPagedList([FromQuery] int page, [FromQuery] int count)
        {
            var result = service.PagedListUsers(page, count);
            return Ok(result);
        }

        [HttpGet("FilterUser")] //kullanıcıları kullanıcı isimlerine göre filtreleme
        public IActionResult GetFilterUser([FromQuery] string key)
        {
            var result = service.FilterUsers(key);
            return Ok(result);
        }

        [HttpPost("AddUser")] //kullanıcı eklendiğinde event fırlat
        public IActionResult AddUser([FromQuery] string key)
        {
            var result = service.FilterUsers(key);

            if(result is not null)
            {
                var connectioFactory = new ConnectionFactory()
                {
                    HostName = "localhost",
                    VirtualHost = "/",
                    Port = 5672,
                    UserName = "guest",
                    Password = "guest"
                };

                using var connection = connectioFactory.CreateConnection();
                using var channel = connection.CreateModel();
                channel.ExchangeDeclare("fanout.test", "fanout", false, false);

                channel.QueueDeclare("fanout.queue1", false, false, true);

                channel.QueueBind("fanout.queue1", "fanout.test", string.Empty);

                channel.BasicPublish("fanout.test", string.Empty, null, Encoding.UTF8.GetBytes("Kullanıcı Eklendi"));

                Console.WriteLine("Gönderildi");

                channel.Close();
                connection.Close();

                Console.Read();
            }
            return Ok(result);
        }

    }
}

