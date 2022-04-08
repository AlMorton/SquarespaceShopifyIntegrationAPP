namespace SquarespaceShopifyIntegrationAPP.BackgroundWorker
{
    public class TransferService : BackgroundService
    {
        private readonly TransferEventQueue _queue;

        public TransferService(TransferEventQueue queue)
        {
            _queue = queue;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _queue.ListenForEventsAsync();
        }
    }

   
}
