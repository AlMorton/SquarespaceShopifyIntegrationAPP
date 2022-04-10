
using Application.UseCases;
using Application.UseCases.Products;

namespace Application.Interfaces
{
    public interface IShopifyClient
    {
        Task<ProductEntity> CreateProduct(Product product);
    }
}