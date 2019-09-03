using Autofac;
using ManualHelp.Common.Dispatchers.Abstract;
using ManualHelp.Common.Handlers.Abstract;
using ManualHelp.Common.Messages.Abstract;
using ManualHelp.Common.RabbitMq.Implementation;
using System.Threading.Tasks;


namespace ManualHelp.Common.Dispatchers.Implementation
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IComponentContext _context;

        public CommandDispatcher(IComponentContext context)
        {
            _context = context;
        }

        public async Task SendAsync<T>(T command) where T : ICommand
            => await _context.Resolve<ICommandHandler<T>>().HandleAsync(command, CorrelationContext.Empty);
    }
}
