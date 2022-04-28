
using Application.UseCases;
using Application.UseCases.Products;

namespace Application.Interfaces
{
    public interface IShopifyProductClient
    {
        Task<ProductEntity> CreateProduct(Product product);
    }
}