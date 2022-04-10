using Application.Events;
using Application.UseCases;
using System.Threading.Channels;

namespace SquarespaceShopifyIntegrationAPP.BackgroundWorker
{
    public class TransferEventQueue : IQueueTask
    {
        private readonly Channel<TransferEvent> _tasks = Channel.CreateUnbounded<TransferEvent>();

        private readonly ILogger<TransferEventQueue> _logger;

        public TransferEventQueue(ILogger<TransferEventQueue> logger)
        {
            _logger = logger;            
        }
        public async Task ListenForEventsAsync(Func<TransferEvent, Task> action)
        {
            await foreach (TransferEvent? @event in _tasks.Reader.ReadAllAsync())
            {         
                try
                {
                     await action.Invoke(@event);

                     await Task.Delay(1000);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                }

            }
        }

        public async Task QueueEvent(TransferEvent @event)
        {
            await _tasks.Writer.WriteAsync(@event, new CancellationToken());
        }
    }
}
