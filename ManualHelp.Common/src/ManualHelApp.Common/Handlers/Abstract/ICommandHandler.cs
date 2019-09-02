using ManualHelp.Common.Messages.Abstract;
using ManualHelp.Common.RabbitMq.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ManualHelp.Common.Handlers.Abstract
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        Task HandleAsync(TCommand command, ICorrelationContext context);
    }
}
