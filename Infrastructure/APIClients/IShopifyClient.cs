
namespace Infrastructure.APIClients
{
    public interface IShopifyClient
    {
        Task<bool> CreateProduct(Product product);
    }
}