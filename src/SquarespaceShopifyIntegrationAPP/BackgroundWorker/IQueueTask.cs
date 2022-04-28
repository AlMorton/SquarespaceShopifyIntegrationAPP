using Application.Events;

namespace SquarespaceShopifyIntegrationAPP.BackgroundWorker
{
    public interface IQueueTask
    {
        Task QueueEvent(TransferEvent @event);
    }
}
