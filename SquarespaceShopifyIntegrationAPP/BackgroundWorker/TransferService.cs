using Application.UseCases;
using Application.UseCases.Products;
using Microsoft.AspNetCore.SignalR;
using SquarespaceShopifyIntegrationAPP.Hubs;

namespace SquarespaceShopifyIntegrationAPP.BackgroundWorker
{
    public class TransferService : BackgroundService
    {
        private readonly TransferEventQueue _queue;        
        private readonly IServiceProvider _serviceProvider;
        private readonly IHubContext<TransferJobHub, ITransferJobHub> _hubContext;

        private CreateShopifyProductFromSquareSpace_UseCase _createShopifyProduct_UseCase;
        public TransferService(TransferEventQueue queue, IServiceProvider serviceProvider, IHubContext<TransferJobHub, ITransferJobHub> hubContext)
        {
            _queue = queue;
            _serviceProvider = serviceProvider;
            _hubContext = hubContext;   
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using var scope = _serviceProvider.CreateScope();

            _createShopifyProduct_UseCase = scope.ServiceProvider.GetRequiredService<CreateShopifyProductFromSquareSpace_UseCase>();

            await _queue.ListenForEventsAsync(async (@event) =>
            {
                foreach (var item in @event.CollectionDTO.Items)
                {
                    var productId = await _createShopifyProduct_UseCase.HandleAsync(item);

                    await _hubContext.Clients.All.ReceiveMessage(productId.ToString());
                    // link to collection;
                }                

                
            });
        }
    }

   
}
