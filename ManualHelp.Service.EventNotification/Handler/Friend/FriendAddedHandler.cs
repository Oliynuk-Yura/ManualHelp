using ManualHelp.Common.Handlers.Abstract;
using ManualHelp.Common.RabbitMq.Abstract;
using ManualHelp.Service.EventNotification.Messages.Event;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManualHelp.Service.EventNotification.Handler.Friend
{
    public class FriendAddedHandler : IEventHandler<FriendAdded>
    {
        private readonly ILogger<FriendAddedHandler> _logger;

        public FriendAddedHandler
            (
            ILogger<FriendAddedHandler> logger
            )
        {
            _logger = logger;
        }

        public Task HandleAsync(FriendAdded @event, ICorrelationContext context)
        {
            _logger.LogInformation($"Friend added {@event.FriendId}");

            return Task.CompletedTask;
        }
    }
}
