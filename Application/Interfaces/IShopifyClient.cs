
using Application.UseCases;
using static Application.UseCases.Root;

namespace Application.Interfaces
{
    public interface IShopifyClient
    {
        Task<bool> CreateProduct(Product product);
    }
}