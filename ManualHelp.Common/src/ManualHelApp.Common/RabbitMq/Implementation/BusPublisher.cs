using ManualHelp.Common.Messages.Abstract;
using ManualHelp.Common.RabbitMq.Abstract;
using RawRabbit;
using RawRabbit.Enrichers.MessageContext;
using System.Threading.Tasks;

namespace ManualHelp.Common.RabbitMq.Implementation
{
    public class BusPublisher : IBusPublisher
    {
        private readonly IBusClient _busClient;

        public BusPublisher(IBusClient busClient)
        {
            _busClient = busClient;
        }

        public async Task PublishCommandAsync<TCommand>(TCommand command, ICorrelationContext context) where TCommand : ICommand
        {
            await _busClient.PublishAsync(command, ctx => ctx.UseMessageContext(context));
        }

        public async Task PublishEventAsync<TEvent>(TEvent @event, ICorrelationContext context) where TEvent : IEvent
        {
            await _busClient.PublishAsync(@event, ctx => ctx.UseMessageContext(context));
        }
    }
}
