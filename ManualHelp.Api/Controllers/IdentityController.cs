using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManualHelp.Api.Messages.Command.Identity;
using ManualHelp.Common.RabbitMq.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace ManualHelp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : BaseController
    {
        public IdentityController(IBusPublisher busPublisher) : base(busPublisher)
        {
        }

        public async Task<IActionResult> Index()
        {
            await SendAsync(new SignUpUser
            {
                Email = "test@test.ree",
                Password = "Qwerty1234511!"
            }, resource: "identity");

            return Ok();
        }

        public async Task<IActionResult> SignIn()
        {
            await SendAsync(new SignUpUser
            {
                Email = "test@test.ree",
                Password = "Qwerty1234511!"
            }, resource: "identity");

            return Ok();
        }
    }
}