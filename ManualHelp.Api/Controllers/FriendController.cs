using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManualHelp.Api.Messages.Command.Friend;
using ManualHelp.Common.RabbitMq.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace ManualHelp.Api.Controllers
{
    public class FriendController : BaseController
    {
        public FriendController(IBusPublisher busPublisher) : base(busPublisher)
        {
        }


        public async Task<IActionResult> Index()
        {
           await SendAsync<AddFriend>(new AddFriend()
            {
                FriendId = new Guid(),
                UserId = new Guid(),
                Id = new Guid() 
            }, resource: "friend");

            return Ok();
        }
    }
}