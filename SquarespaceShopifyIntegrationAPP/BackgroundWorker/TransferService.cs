using Application.UseCases;

namespace SquarespaceShopifyIntegrationAPP.BackgroundWorker
{
    public class TransferService : BackgroundService
    {
        private readonly TransferEventQueue _queue;
        private CreateShopifyItem_UseCase _createShopifyItem_UseCase;
        private readonly IServiceProvider _serviceProvider;
        public TransferService(TransferEventQueue queue, IServiceProvider serviceProvider)
        {
            _queue = queue;
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using var scope = _serviceProvider.CreateScope();

            _createShopifyItem_UseCase = scope.ServiceProvider.GetRequiredService<CreateShopifyItem_UseCase>();

            await _queue.ListenForEventsAsync(async (@event) =>
            {
                await _createShopifyItem_UseCase.HandleAsync(@event);
            });
        }
    }

   
}
