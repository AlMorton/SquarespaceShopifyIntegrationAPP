using Infrastructure.APIClients.ShopifyJSONModels;

namespace Infrastructure.APIClients
{
    public interface IShopifyCollectionClient
    {
        Task<CustomCollectionEntity> CreateCollection(CustomCollectionPost customCollection);
        Task<CollectEntity> LinkProductToCollection(CollectLinkPost collectLink);
    }
}