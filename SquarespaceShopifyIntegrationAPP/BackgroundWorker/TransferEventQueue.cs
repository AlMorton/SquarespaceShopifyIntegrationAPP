using Infrastructure.APIClients;
using Infrastructure.Webscrappers;
using System.Threading.Channels;

namespace SquarespaceShopifyIntegrationAPP.BackgroundWorker
{
    public class TransferEventQueue : IQueueTask, ITaskViewer
    {
        private readonly Channel<TransferEvent> _tasks = Channel.CreateUnbounded<TransferEvent>();

        private readonly ISquareSpaceScrapper _squareSpaceScrapper;
        private readonly IShopifyClient _shopifyClient;
        private readonly ILogger<TransferEventQueue> _logger;

        public TransferEventQueue(ISquareSpaceScrapper squareSpaceScrapper, IShopifyClient shopifyClient, ILogger<TransferEventQueue> logger)
        {
            _squareSpaceScrapper = squareSpaceScrapper;
            _shopifyClient = shopifyClient;
            _logger = logger;
        }

        public List<TransferEvent> EventsBeingProccessed { get; private set; } = new List<TransferEvent>();

        public async Task ListenForEventsAsync()
        {
            await foreach (var @event in _tasks.Reader.ReadAllAsync())
            {
                EventsBeingProccessed.Add(@event);
                try
                {
                    var item = _squareSpaceScrapper.GetItemDetails(@event.ItemURL);

                    var product = new Product
                    {
                        body_html = item.Description,
                        images = item.ImageUrls.Select(u => new Image
                        {
                            src = u,
                        }).ToList(),
                        image = item.ImageUrls.Take(1).Select(u => new Image
                        {
                            src = u,
                        }).First(),
                        product_type = "Picture",
                        title = item.Title,
                        vendor = "Test"
                    };

                    await _shopifyClient.CreateProduct(product);

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

    public interface IQueueTask
    {
        Task QueueEvent(TransferEvent @event);
    }
    public interface ITaskViewer
    {
        List<TransferEvent> EventsBeingProccessed { get; }
    }

    public class TransferEvent
    {
        public Guid Id { get; }
        public string ItemURL { get; }

        public TransferEvent(string url)
        {
            Id = Guid.NewGuid();
            ItemURL = url;
        }
    }
}
