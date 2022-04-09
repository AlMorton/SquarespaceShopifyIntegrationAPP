using Application.UseCases;
using Application.UseCases.Products;

namespace Infrastructure.APIClients
{
    public interface ISqaureSpaceClient
    {
        Task<List<CollectionItem>> GetCollectionItemsAsync(string url);
    }
}