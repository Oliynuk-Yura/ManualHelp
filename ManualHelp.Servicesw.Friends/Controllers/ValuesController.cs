using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManualHelp.Common.Handlers.Abstract;
using ManualHelp.Services.Friends.Domain;
using ManualHelp.Services.Friends.Handler.Friends;
using ManualHelp.Services.Friends.Messages.Commands.Friends;
using ManualHelp.Services.Friends.Repository.Abstract;
using ManualHelp.Services.Friends.Repository.Implementation;
using Microsoft.AspNetCore.Mvc;

namespace ManualHelp.Servicesw.Friends.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ICommandHandler<AddFriend> _commandHandler;

        public ValuesController
            (
           ICommandHandler<AddFriend> commandHandler
            )
        {
            _commandHandler = commandHandler;
        }
        // GET api/values
        [HttpGet]
        public async  Task<ActionResult<IEnumerable<string>>> Get()
        {

            //await _commandHandler.HandleAsync
            //     (new AddFriend()
            //     {
            //         UserId = new Guid(),
            //         FriendId = new Guid()
            //     }, null);

            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
