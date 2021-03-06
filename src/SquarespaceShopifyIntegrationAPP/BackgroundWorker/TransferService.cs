using Application.UseCases;
using Application.UseCases.Products;
using Infrastructure.APIClients;
using Infrastructure.APIClients.ShopifyJSONModels;
using Microsoft.AspNetCore.SignalR;
using SquarespaceShopifyIntegrationAPP.Hubs;

namespace SquarespaceShopifyIntegrationAPP.BackgroundWorker
{
    public class TransferService : BackgroundService
    {
        private readonly TransferEventQueue _queue;
        private readonly IServiceProvider _serviceProvider;
        private readonly IHubContext<TransferJobHub, ITransferJobHub> _hubContext;
        private readonly ILogger<TransferService> _logger;

        private IShopifyCollectionClient _shopifyCollectionClient;

        private CreateShopifyProductFromSquareSpace_UseCase _createShopifyProduct_UseCase;
        public TransferService(TransferEventQueue queue, IServiceProvider serviceProvider, IHubContext<TransferJobHub, ITransferJobHub> hubContext, ILogger<TransferService> logger)
        {
            _queue = queue;
            _serviceProvider = serviceProvider;
            _hubContext = hubContext;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using var scope = _serviceProvider.CreateScope();

            _shopifyCollectionClient = scope.ServiceProvider.GetRequiredService<IShopifyCollectionClient>();
            _createShopifyProduct_UseCase = scope.ServiceProvider.GetRequiredService<CreateShopifyProductFromSquareSpace_UseCase>();

            await _queue.ListenForEventsAsync(async (@event) =>
            {
                try
                {
                    var collection = await _shopifyCollectionClient.CreateCollection(new CustomCollectionPost
                    {
                        title = @event.CollectionDTO.CollectionName
                    });

                    foreach (var item in @event.CollectionDTO.Items)
                    {
                        var productId = await _createShopifyProduct_UseCase.HandleAsync(item);

                        await Task.Delay(1000);

                        await _shopifyCollectionClient.LinkProductToCollection(new CollectLinkPost
                        {
                            collection_id = collection.Id,
                            product_id = productId
                        });

                        await _hubContext.Clients.All.ReceiveMessage(productId.ToString());
                        // link to collection;
                    }

                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                };
            });
        }
    }


}
