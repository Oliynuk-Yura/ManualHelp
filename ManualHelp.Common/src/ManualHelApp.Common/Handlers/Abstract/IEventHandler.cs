using ManualHelp.Common.Messages.Abstract;
using ManualHelp.Common.RabbitMq.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ManualHelp.Common.Handlers.Abstract
{
    public interface IEventHandler<in TEvent> where TEvent : IEvent
    {
        Task HandleAsync(TEvent @event, ICorrelationContext context);
    }
}
