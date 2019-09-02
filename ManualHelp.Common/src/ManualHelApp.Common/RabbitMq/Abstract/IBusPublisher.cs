using ManualHelp.Common.Messages.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ManualHelp.Common.RabbitMq.Abstract
{
   public interface IBusPublisher
   {
        Task PublishCommandAsync<TCommand>(TCommand command, ICorrelationContext context)
            where TCommand : ICommand;

        Task PublishEventAsync<TEvent>(TEvent @event, ICorrelationContext context)
             where TEvent : IEvent;
   }
}
