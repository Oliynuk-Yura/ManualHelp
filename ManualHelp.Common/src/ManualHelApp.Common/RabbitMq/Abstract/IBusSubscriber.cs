using ManualHelp.Common.Messages.Abstract;
using ManualHelp.Common.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManualHelp.Common.RabbitMq.Abstract
{
    public interface IBusSubscriber
    {
        IBusSubscriber SubscribeCommand<TCommand>(string @namespace = null, string queueName = null,
            Func<TCommand, ManualHelpException, IRejectedEvent> onError = null)
            where TCommand : ICommand;

        IBusSubscriber SubscribeEvent<TEvent>(string @namespace = null, string queueName = null,
           Func<TEvent, ManualHelpException, IRejectedEvent> onError = null)
           where TEvent : IEvent;
    }
}
